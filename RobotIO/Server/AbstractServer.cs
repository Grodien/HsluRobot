using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace RobotIO.Server
{
  public abstract class AbstractServer
  {
    protected volatile bool Stopped;

    protected IDictionary<string, IRequestHandler> RequestDict;

    /// <summary>
    /// Gets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    protected string Identifier { get; private set; }

    protected AbstractServer(string identifier)
    {
      Identifier = identifier;
      RequestDict = new Dictionary<string, IRequestHandler>();
    }

    /// <summary>
    /// Starts this server.
    /// </summary>
    public void Start()
    {
      AddRequestHandlers();
      new Thread(DoStart).Start();
    }

    protected abstract void AddRequestHandlers();

    protected void Log(string format, params object[] strings)
    {
      Console.WriteLine(format, strings);
    }

    private void DoStart()
    {
      try
      {
        Console.WriteLine("{0}: Start.", Identifier);
        StartListener();
      }
      catch (Exception exception)
      {
        Console.WriteLine("{0}: Aborted unexpected by {1}.", Identifier, exception);
      }
      finally
      {
        Console.WriteLine("{0}: Stopped.", Identifier);
      }
    }

    /// <summary>
    /// Starts the listener. 
    /// This is the main loop to accept new clients.
    /// </summary>
    protected abstract void StartListener();

    /// <summary>
    /// Stops this instance without waiting on termination!
    /// </summary>
    public void Stop()
    {
      Console.WriteLine("{0}: Stopping...", Identifier);
      Stopped = true;
      OnStop();         
    }

    protected virtual void OnStop() { }                           

    protected abstract Client CreateClient(string ip, NetworkStream networkStream);

    protected void ProcessClientSync(string ip, NetworkStream networkStream, Action finishedCallback)
    {
      try
      {
        Console.WriteLine("{0}: Client <{1}> connected.", Identifier, ip);        
        ProcessClient(CreateClient(ip, networkStream));
      }
      catch (Exception exception)
      {
        Console.WriteLine("{0}: Client <{1}> aborted by exception: {2}", Identifier, ip, exception);
      }
      finally
      {
        Console.WriteLine("{0}: Client <{1}> finished.", Identifier, ip);
        networkStream.Flush();
        if (finishedCallback != null)
          finishedCallback();
      }
    }

    private void ProcessClient(Client client)
    {
      while (true)
      {
        string request = client.ReadRequest();
        if (string.IsNullOrEmpty(request))
          break;

        string[] requestParts = request.Split(' ');
        IRequestHandler handler = GetHandler(requestParts);
        if (handler == null)
        {
          Console.WriteLine("{0}: Client <{1}> Unknown Request received: {2}", Identifier, client.IP, request);
        }
        else
        {
          Console.WriteLine("{0}: Client <{1}> Request: <{2}>", Identifier, client.IP, request);
          string response = handler.Process(requestParts);
          
          Console.WriteLine("{0}: Client <{1}> Response: {2}", Identifier, client.IP, response.Length > 100 ? response.Substring(0,100) : response);
          if (!string.IsNullOrEmpty(response))
          {
            client.SendResponse(response);
          }
        }
      }
    }

    protected virtual IRequestHandler GetHandler(string[] requestParts)
    {
      IRequestHandler requestHandler;
      RequestDict.TryGetValue(requestParts[0], out requestHandler);
      return requestHandler;
    }
  }
}