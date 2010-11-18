//
//  Commands.cs
//  
//  Author:
//       Karl Voelker <ktvoelker@gmail.com>
// 
//  Copyright (c) 2010 Karl Voelker
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
namespace Di.Model.Command
{
    public class CommandMode : LoneCommand
    {
        #region implemented abstract members of Di.Model.LoneCommand
        public override void Execute(Main m)
        {
            throw new System.NotImplementedException();
        }
        
        #endregion
    }

    public class Down : MoveCommand
    {
        #region implemented abstract members of Di.Model.MoveCommand
        public override Movement Evaluate(Main m)
        {
            throw new System.NotImplementedException();
        }
        
        #endregion
    }

    public class Ignore : LoneCommand
    {
        #region implemented abstract members of Di.Model.LoneCommand
        public override void Execute(Main m)
        {
            throw new System.NotImplementedException();
        }
        
        #endregion
    }

    public class InsertKey : RepeatCommand
    {
        public override void Execute(Main m)
        {
            throw new NotImplementedException();
        }
    }

    public class InsertMode : LoneCommand
    {
        #region implemented abstract members of Di.Model.LoneCommand
        public override void Execute(Main m)
        {
            throw new System.NotImplementedException();
        }
        
        #endregion
    }
}
