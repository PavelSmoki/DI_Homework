using System;
using UnityEngine;

namespace Lesson
{
   public interface ICharacter
   {
      Vector3 GetCurrentPosition();
      void Setup(Action death);
      void MoveTo(Vector3 pos);
   }
}
