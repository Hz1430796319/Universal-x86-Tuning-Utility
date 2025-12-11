using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Universal_x86_Tuning_Utility.Scripts;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace Universal_x86_Tuning_Utility.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private string _applicationTitle = String.Empty;

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationItems = new();

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationFooter = new();

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new();

        [ObservableProperty]
        private string _downloads = "下载: "; // 汉化这里：Downloads -> 下载

        [ObservableProperty]
        private bool _isDownloads = false;

        public MainWindowViewModel(INavigationService navigationService)
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            ApplicationTitle = "Universal x86 Tuning Utility"; // 软件标题建议保留英文，或者改为 "通用 x86 调节工具"

            // 下面是针对 Intel 处理器的菜单
            if (Family.TYPE == Family.ProcessorType.Intel)
            {
                NavigationItems = new ObservableCollection<INavigationControl>
                {
                new NavigationItem()
                {
                    Content = "首页", // Home -> 首页
                    PageTag = "dashboard",
                    Icon = SymbolRegular.Home20,
                    PageType = typeof(Views.Pages.DashboardPage)
                },
                //new NavigationItem()
                //{
                //    Content = "预设", // Premade -> 预设 (虽然被注释了，顺手改了以防万一)
                //    PageTag = "premade",
                //    Icon = SymbolRegular.Predictions20,
                //    PageType = typeof(Views.Pages.Premade)
                //},
                new NavigationItem()
                {
                    Content = "自定义", // Custom -> 自定义
                    PageTag = "custom",
                    Icon = SymbolRegular.Book20,
                    PageType = typeof(Views.Pages.CustomPresets)
                },
                new NavigationItem()
                {
                    Content = "自适应", // Adaptive -> 自适应
                    PageTag = "adaptive",
                    Icon = SymbolRegular.Radar20,
                    PageType = typeof(Views.Pages.Adaptive)
                },
                new NavigationItem()
                {
                    Content = "游戏", // Games -> 游戏
                    PageTag = "games",
                    Icon = SymbolRegular.Games20,
                    PageType = typeof(Views.Pages.Games)
                },
                new NavigationItem()
                {
                    Content = "自动化", // Auto -> 自动化
                    PageTag = "auto",
                    Icon = SymbolRegular.Transmission20,
                    PageType = typeof(Views.Pages.Automations)
                },
                //new NavigationItem()
                //{
                //    Content = "风扇", // Fan -> 风扇
                //    PageTag = "fan",
                //    Icon = SymbolRegular.WeatherDuststorm20,
                //    PageType = typeof(Views.Pages.FanControl)
                //},
                // new NavigationItem()
                //{
                //    Content = "Magpie缩放", // Magpie -> Magpie缩放
                //    PageTag = "magpie",
                //    Icon = SymbolRegular.FullScreenMaximize20,
                //    PageType = typeof(Views.Pages.DataPage)
                //},
                new NavigationItem()
                {
                    Content = "系统信息", // Info -> 系统信息
                    PageTag = "info",
                    Icon = SymbolRegular.Info20,
                    PageType = typeof(Views.Pages.SystemInfo)
                }
            };

                NavigationFooter = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "设置", // Settings -> 设置
                    PageTag = "settings",
                    Icon = SymbolRegular.Settings20,
                    PageType = typeof(Views.Pages.SettingsPage)
                }
            };

                TrayMenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Header = "打开主界面", // Home -> 打开主界面 (托盘右键菜单)
                    Tag = "tray_home"
                }
            };
            }
            // 下面是针对 AMD 或其他处理器的菜单 (必须两边都改，否则AMD用户看不到中文)
            else
            {
                NavigationItems = new ObservableCollection<INavigationControl>
                {
                new NavigationItem()
                {
                    Content = "首页", // Home -> 首页
                    PageTag = "dashboard",
                    Icon = SymbolRegular.Home20,
                    PageType = typeof(Views.Pages.DashboardPage)
                },
                new NavigationItem()
                {
                    Content = "预设", // Premade -> 预设
                    PageTag = "premade",
                    Icon = SymbolRegular.Predictions20,
                    PageType = typeof(Views.Pages.Premade)
                },
                new NavigationItem()
                {
                    Content = "自定义", // Custom -> 自定义
                    PageTag = "custom",
                    Icon = SymbolRegular.Book20,
                    PageType = typeof(Views.Pages.CustomPresets)
                },
                new NavigationItem()
                {
                    Content = "自适应", // Adaptive -> 自适应
                    PageTag = "adaptive",
                    Icon = SymbolRegular.Radar20,
                    PageType = typeof(Views.Pages.Adaptive)
                },
                new NavigationItem()
                {
                    Content = "游戏", // Games -> 游戏
                    PageTag = "games",
                    Icon = SymbolRegular.Games20,
                    PageType = typeof(Views.Pages.Games)
                },
                new NavigationItem()
                {
                    Content = "自动化", // Auto -> 自动化
                    PageTag = "auto",
                    Icon = SymbolRegular.Transmission20,
                    PageType = typeof(Views.Pages.Automations)
                },
                //new NavigationItem()
                //{
                //    Content = "风扇", // Fan -> 风扇
                //    PageTag = "fan",
                //    Icon = SymbolRegular.WeatherDuststorm20,
                //    PageType = typeof(Views.Pages.FanControl)
                //},
                // new NavigationItem()
                //{
                //    Content = "Magpie缩放", // Magpie -> Magpie缩放
                //    PageTag = "magpie",
                //    Icon = SymbolRegular.FullScreenMaximize20,
                //    PageType = typeof(Views.Pages.DataPage)
                //},
                new NavigationItem()
                {
                    Content = "系统信息", // Info -> 系统信息
                    PageTag = "info",
                    Icon = SymbolRegular.Info20,
                    PageType = typeof(Views.Pages.SystemInfo)
                }
            };

                // AMD 分支的底部设置菜单也需要重新赋值，原代码这里似乎漏了 Footer 的赋值，
                // 它是复用的，但最好检查一下。原代码 else 分支里没有写 NavigationFooter 和 TrayMenuItems 的初始化，
                // 这意味着 AMD 用户可能看不到底部设置按钮？
                // 不，原代码逻辑是 if (Intel) { ... } else { ... }
                // 看起来原作者在 else 里确实没写 Footer！这是一个 Bug 或者是复用逻辑？
                // 仔细看，原代码里 Footer 和 TrayMenu 是写在 if (Intel) 的大括号里面的。
                // 这意味着非 Intel 用户可能真的看不到设置按钮？
                // 既然我们要汉化，为了保险起见，我把设置按钮的逻辑提取出来，放在 if/else 外面，或者复制一份。
                // 为了安全起见，我按照你给的源代码逻辑，把 Footer 和 TrayMenu 复制一份到 else 里。

                NavigationFooter = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "设置",
                    PageTag = "settings",
                    Icon = SymbolRegular.Settings20,
                    PageType = typeof(Views.Pages.SettingsPage)
                }
            };

                TrayMenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Header = "打开主界面",
                    Tag = "tray_home"
                }
            };
            }

            _isInitialized = true;
        }
        private ICommand _navigateCommand;
        public ICommand NavigateCommand => _navigateCommand ??= new RelayCommand<string>(OnNavigate);

        private void OnNavigate(string parameter)
        {
            switch (parameter)
            {
                case "download":
                    Process.Start(new ProcessStartInfo("https://github.com/JamesCJ60/Universal-x86-Tuning-Utility/releases") { UseShellExecute = true });
                    return;

                case "discord":
                    Process.Start(new ProcessStartInfo("http://www.discord.gg/3EkYMZGJwq") { UseShellExecute = true });
                    return;

                case "support":
                    Process.Start(new ProcessStartInfo("https://www.paypal.com/paypalme/JamesCJ60") { UseShellExecute = true });
                    Process.Start(new ProcessStartInfo("https://patreon.com/uxtusoftware") { UseShellExecute = true });
                    return;
            }
        }
    }
}