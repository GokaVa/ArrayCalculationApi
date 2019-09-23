using ArrayReversingApi.Interface;
using System;

namespace ArrayReversingApi.Services
{
    public class ArrayReversingService : IArrayReversingService
    {
        public int[] ManipulatedArray(string[] array)
        {
            var arrayLength = array.Length;
            var newArray = new int[arrayLength];

            var index = 0;
            for (int i = arrayLength - 1; i >= 0; i--)
            {
                newArray[index] = ConvertToIntOrThrowException(array[i]);
                index++;
            }
            return newArray;
        }

        public int[] DeletedArrayElement(string[] array, string strPosition)
        {
            // when position not provided or it is out of range, new array will be same size as original
            var position = string.IsNullOrEmpty(strPosition) ? 0 : ConvertToIntOrThrowException(strPosition);
            var arraySize = array.Length;
            var newArraySize = (position < 1 || position > arraySize) ? arraySize : arraySize - 1;
            var newArray = new int[newArraySize];

            var index = 0;
            for (int i = 0; i < arraySize; i++)
            {
                if (i != position - 2)
                {
                    newArray[index] = ConvertToIntOrThrowException(array[i]);
                    index++;
                }
            }
            return newArray;
        }
        private int ConvertToIntOrThrowException(string stringElement)
        {
            int element;
            if (!int.TryParse(stringElement, out element))
            {
                throw new Exception("NaN");
            }
            return element;
        }
    }
}
