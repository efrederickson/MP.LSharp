/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/28/2011
 * Time: 10:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using LSharp;

namespace LSharp.Libraries
{
    /// <summary>
    /// The class that contains the Libraries definitions
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Creates the Library entries for L#
        /// </summary>
        /// <param name="environment"></param>
        public Container(Environment environment)
        {
            environment.Assign(Symbol.FromName("gui-inspect"), new Function(GuiInspect));
            environment.Assign(Symbol.FromName("play-sound"), new Function(PlaySound));
        }
        
        /// <summary>
        /// (gui-inspect OBJECT)
        /// shows a Form with data on the item OBJECT
        /// </summary>
        /// <param name="args"></param>
        /// <param name="environment"></param>
        /// <returns></returns>
        public static object GuiInspect(Cons args, Environment environment)
        {
            // TODO : Fix
            //string sname = (string) Functions.SymbolName(new Cons(args.First()), environment);
            InspectorForm i = new InspectorForm(args.Car());
            i.ShowDialog();
            return args.First();
        }
        
        /// <summary>
        /// (play-sound filename)
        /// Plays the sound from filename
        /// </summary>
        /// <param name="args"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static object PlaySound(Cons args, Environment e)
        {
            return Sound.Play((string) args.Car());
        }
    }
}
