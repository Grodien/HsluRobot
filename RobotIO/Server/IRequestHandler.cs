namespace RobotIO.Server
{
  public interface IRequestHandler
  {
    string Process(string[] request);
  }
}