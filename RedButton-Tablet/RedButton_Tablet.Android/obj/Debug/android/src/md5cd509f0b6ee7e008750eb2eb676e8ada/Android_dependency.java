package md5cd509f0b6ee7e008750eb2eb676e8ada;


public class Android_dependency
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("RedButton_Tablet.Droid.Android_dependency, RedButton_Tablet.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Android_dependency.class, __md_methods);
	}


	public Android_dependency () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Android_dependency.class)
			mono.android.TypeManager.Activate ("RedButton_Tablet.Droid.Android_dependency, RedButton_Tablet.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
