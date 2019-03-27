using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Configuration;

namespace TCQ_MVCEF.Common
{
    public class PartialCacheAttribute:OutputCacheAttribute
    {
        public PartialCacheAttribute(string cacheprofileName)
        {
            OutputCacheSettingsSection outputCacheSettingsSection = (OutputCacheSettingsSection)
                WebConfigurationManager.GetSection("system.web/caching/outputCacheSettings");
            OutputCacheProfile outputCacheProfile = outputCacheSettingsSection.OutputCacheProfiles[cacheprofileName];
            Duration = outputCacheProfile.Duration;
            VaryByParam = outputCacheProfile.VaryByParam;

        }
    }
}