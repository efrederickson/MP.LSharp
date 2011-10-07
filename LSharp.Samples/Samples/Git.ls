;;; Example to use shell and Git (or any external program)

(reference "System" "System.Core" "mscorlib")
(using "System.Diagnostics")

(prl "Creating Start Info...")
(= psi (new ProcessStartInfo))
(set_FileName psi "git")
(set_Arguments psi "clone http://www.github.com/mlnlover11/MP.LSharp.git LSharp")

(prl "Creating Process Info...")
(= process (new Process))
(set_StartInfo process psi)
(defevent Exited process (sender e) (prl "Git finished!"))

(prl "Starting Process...")
(call start process) 