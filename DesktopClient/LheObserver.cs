using Backend.Filters;
using DesktopClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient
{
    public class LheObserver
    {
        public static LheObserver Instance { get;  }

        static LheObserver()
        {
            Instance = new LheObserver();
        }


        public List<LesniHospodarskaEvidenceViewModel> Listeners { get; set; }
        private LheObserver()
        {
            Listeners = new List<LesniHospodarskaEvidenceViewModel>();
        }

        public void NotifyFilterConfigChanged(LheFilterConfig cfg)
        {
            foreach (var listener in Listeners)
            {
                listener.OnFilterConfigChanged(cfg);
            }
        }

        public void NotifyLheTableChanged()
        {
            foreach (var listener in Listeners)
            {
                listener.OnLheTableChanged();
            }
        }

    }
}
