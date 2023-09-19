using Castle.DynamicProxy;
using Infrastructure.CrossCuttingConcerns.Exceptions;
using Infrastructure.Utilities.Interceptors;

namespace Infrastructure.Aspects.IdParameter
{
    public class IdCheckAspect : MethodInterception
    {
        protected override void OnBefore(IInvocation invocation)
        {
            int id = (int)invocation.Arguments[0];
            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
        }
    }
}
