using Microsoft.Win32.TaskScheduler;
using System;
using System.Windows.Forms;

namespace TaskSchedulerEditorApp {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            for (int x = 0, cx = args.Length; x < cx; x++) {
                if ("/tn".Equals(args[x], StringComparison.InvariantCultureIgnoreCase)) {
                    x++;
                    if (x < cx) {
                        using (TaskService ts = new TaskService()) {
                            var t = ts.GetTask(args[x]);
                            if (t.ShowEditor()) {
                                t.RegisterChanges();
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}
