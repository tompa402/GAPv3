using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAPv3.Handlers;

namespace GAPv3.Helpers
{
	public static class CredentialsManager
	{
	    public static bool IsIdentical(string username, string password)
	    {
	        
	        var user = username.Split('@').First();

	        return (user == password);
	    }

	    public static string GetDefaultPass(string username)
	    {
            return username.Split('@').First();
        }
	}
}