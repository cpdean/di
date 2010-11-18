//
//  KeyMap.cs
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
using System.Collections.Generic;
using Gdk;
namespace Di.Model
{
    using IEC = IEnumerable<ICommand>;

    public struct KeyInput
    {
        public Key Base
        {
            get;
            set;
        }

        public ModifierType Modifiers
        {
            get;
            set;
        }

        public KeyInput(Key _base, ModifierType _modifiers) : this()
        {
            Base = _base;
            Modifiers = _modifiers;
        }

        public KeyInput(EventKey e) : this()
        {
            Base = e.Key;
            Modifiers = e.State;
        }
    }

    public class KeyMap
    {
        public IEC Default
        {
            get;
            set;
        }

        private IDictionary<KeyInput, IEC> _map;

        public KeyMap()
        {
            Default = new ICommand[] { new Command.Ignore() };
            _map = new Dictionary<KeyInput, IEC>();
        }

        public void SetDefault(params ICommand[] commands)
        {
            Default = commands;
        }

        public void Add(Key _base, ModifierType _modifiers, params ICommand[] commands)
        {
            _map[new KeyInput(_base, _modifiers)] = commands;
        }

        public IEC Lookup(EventKey e)
        {
            var key = new KeyInput(e);
            return _map.ContainsKey(key) ? _map[key] : Default;
        }
    }
}
