using System;
using System.Linq;
using System.Reflection;
using GalaSoft.MvvmLight.Messaging;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Patterns.Diagnostics;
using UFO.Commander.Messages;
using UFO.Commander.ViewModel;

namespace UFO.Commander.Handler
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method | MulticastTargets.InstanceConstructor, AllowMultiple = false)]
    public class ViewExceptionHandlerAttribute : OnExceptionAspect
    {
        protected string Title;
        protected string Message;

        public ViewExceptionHandlerAttribute(string title = "", string message = "")
        {
            this.Title = title;
            this.Message = message;
        }

        [Log]
        public override void OnException(MethodExecutionArgs args)
        {
            args.FlowBehavior = FlowBehavior.Continue;
            Messenger.Default.Send(new ExceptionDialogMessage(ViewModelLocator.ExceptionDialogViewModel));
        }
        
    }
}
