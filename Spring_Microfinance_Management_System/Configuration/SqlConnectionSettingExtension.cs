
namespace Spring_Microfinance_Management_System.Framework.Configuration
{
    using System;
    using System.Linq;

    /// <summary>
    /// <see cref="SqlConnectionSetting"/> 
    /// </summary>
    public static class SqlConnectionSettingExtension
    {
        /// <summary>
        /// <see cref="SqlConnectionSetting"/> 。
        /// </summary>
        /// <param name="target"><see cref="SqlConnectionSetting"/> 。</param>
        /// <returns> <see cref="SqlConnectionSetting"/> 。</returns>
        /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/></exception>
        /// <remarks>
        /// <see cref="SqlConnectionSettingExtension.GetSetting(SqlConnectionSetting[], string)"/> 
        /// </remarks>
        public static SqlConnectionSetting GetSetting(this SqlConnectionSetting[] target)
        {
            return target.GetSetting(string.Empty);
        }

        /// <summary>
        /// <see cref="SqlConnectionSetting"/> 
        /// </summary>
        /// <param name="target"><see cref="SqlConnectionSetting"/></param>
        /// <param name="settingName"></param>
        /// <returns><see cref="SqlConnectionSetting"/> 。</returns>
        /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> </exception>
        /// <remarks>
        /// <para>
       
        /// </para>
        /// </remarks>
        public static SqlConnectionSetting GetSetting(this SqlConnectionSetting[] target, string settingName)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                var settings = target.Where(x => x.IsDefault).ToList();

                if (settings.Count != 1)
                {
                    throw new ArgumentException(
                        "Framework.config ");
                }

                return settings.First();
            }
            else
            {
                var settings = target.Where(x => x.SettingName == settingName).ToList();

                if (settings.Count == 0)
                {
                    throw new ArgumentException(
                        "Framework.config settingName=" + settingName);
                }

                return settings.First();
            }
        }
    }
}
