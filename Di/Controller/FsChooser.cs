//  
//  FsChooser.cs
//  
//  Author:
//       Karl Voelker <ktvoelker@gmail.com>
// 
//  Copyright (c) 2011 Karl Voelker
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
using System.Collections.Generic;
namespace Di.Controller
{
    public class FsChooserEvents<T> where T : Model.IFsQueryable
    {
        public readonly Event1<FsChooser<T>> Begin = new Event1<FsChooser<T>>();

        public readonly Event1<FsChooser<T>> End = new Event1<FsChooser<T>>();

        public readonly Event0 Cancel = new Event0();
    }

    public class FsChooser<T> where T : Model.IFsQueryable
    {
        private Func<IEnumerable<T>> getCandidates;

        public readonly string Message;

        private Action<T> handler;

        private Action cancelHandler;

        private Di.Model.FsQuery<T> query;

        public string Query
        {
            set
            {
                query = new Di.Model.FsQuery<T>(value);
                Files.Clear();
                Update();
            }
        }

        public BindList<T> Files;

        public FsChooser(Func<IEnumerable<T>> _getCandidates, string _message, Action<T> _handler, Action _cancelHandler)
        {
            getCandidates = _getCandidates;
            handler = _handler;
            Message = _message;
            cancelHandler = _cancelHandler;
            query = new Di.Model.FsQuery<T>("");
            Files = new BindList<T>();
            Update();
        }

        public void Choose(T file)
        {
            handler(file);
        }

        public void Cancel()
        {
            cancelHandler();
        }

        private void Update()
        {
            query.Evaluate(getCandidates()).ForEach(f => Files.Add(f));
        }
    }
}
