namespace Pasjans
{
    /// <summary>
    /// If player interacts with function, return this class so it can get feedback
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ActionResponse<T>
    {
        public T? Value { get; }
        public string Message {get ;}
        public ActionResponse(string message)
        {
            Message = message; 
        }
        public ActionResponse(T value, string message)
        {
           Value = value;
           Message = message; 
        }
        public override string ToString()
        {
            return Message;
        }
    }
}
