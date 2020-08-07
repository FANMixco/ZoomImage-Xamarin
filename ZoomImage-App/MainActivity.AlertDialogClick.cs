using Android.Content;
using Com.Jsibbold.Zoomage;
using Java.Interop;
using System;

namespace ZoomImage_App
{
    public partial class MainActivity
    {
        public class AlertDialogClick : Java.Lang.Object, IDialogInterfaceOnClickListener
        {
            private readonly ZoomageView demoView;

            public AlertDialogClick(ZoomageView demoView) {
                this.demoView = demoView;
            }

            public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

            public void Disposed()
            {

            }

            public void DisposeUnlessReferenced()
            {

            }

            public void Finalized()
            {

            }

            public void OnClick(IDialogInterface dialog, int which)
            {
                demoView.AutoResetMode = which;
            }

            public void SetJniIdentityHashCode(int value)
            {

            }

            public void SetJniManagedPeerState(JniManagedPeerStates value)
            {

            }

            public void SetPeerReference(JniObjectReference reference)
            {

            }
        }
    }
}