using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Base
{
    namespace Runner
    {
        public class CharacterManager : Singleton<CharacterManager>
        {
            public UnityEvent OnArenaSet = new UnityEvent();
            //Character Manager

            public CharacterSettings CurrentCharacter;
        }
    }
}