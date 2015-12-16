using System;
using System.Linq;
using System.Reflection;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Patterns.Diagnostics;

namespace UFO.Commander.Handler
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method | MulticastTargets.InstanceConstructor, AllowMultiple = false)]
    public class ViewClassExceptionHandlerAttribute : OnExceptionAspect
    {
        protected string Title;
        protected string Message;

        public ViewClassExceptionHandlerAttribute(string title = "", string message = "")
        {
            this.Title = title;
            this.Message = message;
        }

        [Log]
        public override void OnException(MethodExecutionArgs args)
        {
            args.FlowBehavior = FlowBehavior.Continue;
        }
        
    }
}
