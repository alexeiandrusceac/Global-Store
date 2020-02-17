using System;
using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using MaterialDesignThemes.Wpf;

namespace GlobalStore.UpdateService
{
    public interface IUpdatable
    {
        string ApplicationName { get;  }
        string ApplicationID { get;  }
        Assembly ApplicationAssembly { get;  }
        Version ApplicationVersion { get; }
        Icon ApplicationIcon { get;  }
        Uri UpdateXmlLocation { get;  }
        Window Context { get; } 
    }
}
