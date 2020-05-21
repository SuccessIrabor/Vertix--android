using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Interop;

namespace Vertix
{
    class SearchOnClickListener : Java.Lang.Object, View.IOnClickListener, View.IOnFocusChangeListener, IMenuItemOnActionExpandListener, IMenuItemOnMenuItemClickListener, Android.Support.V7.Widget.SearchView.IOnCloseListener
    {
        AppCompatActivity activity;
        View parent;

        public SearchOnClickListener(AppCompatActivity activity) : base()
        {
            this.activity = activity;
            this.parent = activity.FindViewById(Resource.Id.content_main);
        }
        /*
        public IntPtr Handle;

        public int JniIdentityHashCode;

        public JniObjectReference PeerReference;

        public JniPeerMembers JniPeerMembers;

        public JniManagedPeerStates JniManagedPeerState;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Disposed()
        {
            throw new NotImplementedException();
        }

        public void DisposeUnlessReferenced()
        {
            throw new NotImplementedException();
        }

        public void Finalized()
        {
            throw new NotImplementedException();
        }
        */
        public void OnClick(View v)
        {
            parent.Foreground = new ColorDrawable(Android.Graphics.Color.Argb((int)(255 * 0.5), 0, 0, 0));
        }
        /*
        public void SetJniIdentityHashCode(int value)
        {
            JniIdentityHashCode = value;
        }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
        {
            JniManagedPeerState = value;
        }

        public void SetPeerReference(JniObjectReference reference)
        {
            PeerReference = reference;
        }

        public void UnregisterFromRuntime()
        {
            
        }
        */
        public void OnFocusChange(View v, bool hasFocus)
        {
            throw new NotImplementedException();
        }

        bool Android.Support.V7.Widget.SearchView.IOnCloseListener.OnClose()
        {
            parent.Foreground = null;
            return false;
        }

        bool IMenuItemOnActionExpandListener.OnMenuItemActionCollapse(IMenuItem item)
        {
            throw new NotImplementedException();
        }

        bool IMenuItemOnActionExpandListener.OnMenuItemActionExpand(IMenuItem item)
        {
            throw new NotImplementedException();
        }

        bool IMenuItemOnMenuItemClickListener.OnMenuItemClick(IMenuItem item)
        {
            throw new NotImplementedException();
        }
    }
}