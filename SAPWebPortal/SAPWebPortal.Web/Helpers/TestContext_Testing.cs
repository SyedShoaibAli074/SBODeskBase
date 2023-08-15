using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using Serenity.Tests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.TestBase
{
    class TestContext_Testing : IRequestContext
    {
        public IBehaviorProvider Behaviors => GetBehavior();
        IBehaviorProvider GetBehavior()
        {
            IBehaviorProvider behavior = new NullBehaviorProvider();
            return behavior;
        }
        public ITwoLevelCache Cache => new NullTwoLevelCache();

        public ITextLocalizer Localizer => GetTextLocalizer();
        public ITextLocalizer GetTextLocalizer()
        {
            ITextLocalizer textLocalizer = new TextLocalizer();
            return textLocalizer;
        }
        public IPermissionService Permissions => GetPermissions();
        public IPermissionService GetPermissions()
        {
            IPermissionService service = new PermissionService();
            return service;
        }
        ClaimsPrincipal IRequestContext.User => User();

        public ClaimsPrincipal User()
        {
            ClaimsPrincipal principal = new Principal();

            return principal;
        }
        internal static string username;
        public TestContext_Testing(String UserName)
        {
            username = UserName;
        }
    }
    class TwoLevelCache : ITwoLevelCache
    {
        public IMemoryCache Memory => new MemoryCache();

        public IDistributedCache Distributed => throw new NotImplementedException();
    }
    class MemoryCache : IMemoryCache
    {
        public ICacheEntry CreateEntry(object key)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(object key, out object value)
        {
            throw new NotImplementedException();
        }
    }
    class Behaviour : IBehaviorProvider
    {
        public IEnumerable Resolve(Type handlerType, Type rowType, Type behaviorType)
        {
            IEnumerable test = null;
            return test;
        }
    }
    class TextLocalizer : ITextLocalizer
    {
        public string TryGet(string key)
        {
            return "";
        }
    }
    class PermissionService : IPermissionService
    {
        public bool HasPermission(string permission)
        {
            return true;
        }
    }
    class Principal : ClaimsPrincipal
    {
        public override IIdentity Identity => getIdentity();
        IIdentity getIdentity()
        {
            IIdentity id = new Identity();

            return id;

        }
    }
    class Identity : IIdentity
    {
        public string AuthenticationType
        {
            get { return "test"; }
        }

        public bool IsAuthenticated { get { return true; } }

        public string Name { get { return TestContext_Testing.username; } }
    }


}
