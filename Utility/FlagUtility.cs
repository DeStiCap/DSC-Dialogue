using System;

namespace DSC.DialogueSystem
{
    public static class FlagUtility
    {
        public static bool HasFlagUnsafe<TEnum>(TEnum hFlags, TEnum hCheckFlag) where TEnum : unmanaged, Enum
        {
 
            unsafe
            {
                switch (sizeof(TEnum))
                {
                    case 1:
                        return (*(byte*)(&hFlags) & *(byte*)(&hCheckFlag)) > 0;
                    case 2:
                        return (*(ushort*)(&hFlags) & *(ushort*)(&hCheckFlag)) > 0;
                    case 4:
                        return (*(uint*)(&hFlags) & *(uint*)(&hCheckFlag)) > 0;
                    case 8:
                        return (*(ulong*)(&hFlags) & *(ulong*)(&hCheckFlag)) > 0;
                    default:
                        throw new Exception("Size does not match a known Enum backing type.");
                }

            }
        }
    }
}