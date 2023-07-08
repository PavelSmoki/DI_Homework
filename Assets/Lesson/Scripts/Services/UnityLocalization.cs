using JetBrains.Annotations;
using UnityEngine.Localization.Settings;

namespace Lesson
{
    [UsedImplicitly]
    public class UnityLocalization : ILocalization
    {
        public string Translate(string key, params object[] args)
        {
            return LocalizationSettings.StringDatabase.GetLocalizedString(LocalizationSettings.StringDatabase.DefaultTable,
                    key, arguments: args);
        }
    }
}