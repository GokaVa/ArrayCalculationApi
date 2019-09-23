

namespace ArrayReversingApi.Interface
{
    public interface IArrayReversingService
    {
        int[] ManipulatedArray(string[] array);
        int[] DeletedArrayElement(string[] array, string position);
    }
}
