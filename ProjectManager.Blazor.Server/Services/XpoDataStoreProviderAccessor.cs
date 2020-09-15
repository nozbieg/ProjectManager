using System;
using DevExpress.ExpressApp.Xpo;

namespace ProjectManager.Blazor.Server.Services {
    public class XpoDataStoreProviderAccessor {
        public IXpoDataStoreProvider DataStoreProvider { get; set; }
    }
}
