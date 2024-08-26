
User usuarioEmisor = new User("Curtis");
User usuarioRecptor = new User("Agos");



Message<string> myMensaje = "dasd";
Console.WriteLine(myMensaje);
myMensaje = "asdasd";
Console.WriteLine(myMensaje);





class Chat
{
    public List<Message<string>> Messages { get; set; }

}

class Message<TSource>
{
    public static TSource _value;

    public Message(TSource value)
    {
        _value = value;
    }

    public static implicit operator Message<TSource>(TSource value)
    {
        return new Message<TSource>(value);
    }

    public static implicit operator TSource(Message<TSource> value)
    {
        return _value;
    }

    public override string? ToString()
    {
        return base.ToString();
    }

}

class User
{
    public string? NickName { get; set; }

    public User(string? nickName)
    {
        NickName = nickName;
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}

