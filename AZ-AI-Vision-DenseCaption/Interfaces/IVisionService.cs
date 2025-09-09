namespace AZ_AI_Vision_DenseCaption.Interfaces
{
    public interface IVisionService
    {
        Task<string> GetDenseCaptionsAsync(string imageUrl);
    }
}
