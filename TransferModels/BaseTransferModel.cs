using Newtonsoft.Json;

public class BaseTransferModel
{
    public long matchId { get; set; }

    public string ToJSON()
    {
        var json = JsonConvert.SerializeObject(this);
        return json;
    }

    public static implicit operator byte[](BaseTransferModel operand)
    {
        var model = operand.ToJSON();
        return System.Text.Encoding.UTF8.GetBytes(model);
    }
}
