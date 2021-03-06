﻿using System.Net.Sockets;
using System.IO;

namespace RobotIO.Server
{
  public class Client
  {
    private readonly NetworkStream _stream;

    private StreamReader _reader;
    protected StreamReader Reader
    {
      get { return _reader = _reader ?? new StreamReader(_stream); }
    }

    private StreamWriter _writer;
    protected StreamWriter Writer
    {
      get { return _writer = _writer ?? new StreamWriter(_stream); }
    }

    public string IP { get; private set; }

    public Client(string ip, NetworkStream stream)
    {
      IP = ip;
      _stream = stream;
    }

    public virtual string ReadRequest()
    {
      return Reader.ReadLine();
    }

    public virtual void SendResponse(string response)
    {
      Writer.WriteLine(response);
      Writer.Flush();
    }
  }
}