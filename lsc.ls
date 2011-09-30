(using "System")
(using "System.CodeDom.Compiler")
(using "System.Collections.Generic")
(using "System.Diagnostics")
(using "System.IO")

(prl "L# Compiler version 1.0 (Written in L#)")
(prl "")
(= env System.Environment)
(= args (GetCommandLineArgs env))

(if (eql (length args) 0)
	(do 
		(prl "Usage: lsc <options> <filenames>\nOptions: -out:<winexe|exe|dll>") 
		(exit 1) ;;; Return failed because no specified input
	)
)

(= ot LSharp.Compiler.OutputType.Exe)
(prl "Compiling ")
(= newArgs1 (new List<string>))
(foreach arg args
	(if (startswith arg "-out:")
		(do 
			(if (endswith arg "winexe")
				(= ot LSharp.Compiler.OutputType.WinFormsExe))
			(if (endswith arg "dll")
				(= ot LSharp.Compiler.OutputType.Dll))
			(if (endswith arg "exe")
				(= ot LSharp.Compiler.OutputType.Exe))
		)
		(do 
			(prl arg " ")
			(add newArgs1 arg)
		)
	)
)
(prl "...")
(= newArgs (new string [count newArgs1])) ;;; FIXME
(TrimExcess newArgs1)
(CopyTo newArgs1 newArgs)
(= r LSharp.Compiler.Compile(newArgs, ot) ;;; FIXME
(if (eql r null) 
	(do 
		(prl "Failed to Compile: Unspecified error!")
		(exit 1)
	)
)
(if (> (length (errors r)) 0)
	(do 
		(foreach err (errors r)
			(prl (tostring err))
			(exit 1)
		)
	)
)
(prl "Compiled to "  (GetFileNameWithoutExtension Path newArgs[0]) (if (eql ot LSharp.Compiler.OutputType.Dll) ".dll" ".exe"));
;;;Process.Start(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(args[0]), System.IO.Path.GetFileNameWithoutExtension(args[0]) + ".exe"));
(exit 0)