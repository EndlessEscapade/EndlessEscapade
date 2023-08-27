﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System.Diagnostics;
using System.Collections;
using System.Runtime.CompilerServices;
using EndlessEscapade.Common.Players;
using EndlessEscapade.Content.Seamap;

namespace EndlessEscapade.Common.Systems.Seamap
{
    internal static class SeamapObjects
    {
        public static SeamapObject[] SeamapEntities = new SeamapObject[2000];

        public static SeamapPlayerShip localship;

        public static ActiveEntitiesEnumerator ActiveEntities => new ActiveEntitiesEnumerator(SeamapEntities);

        public static void InitObjects(Vector2 shipPos)
        {
            SeamapEntities = new SeamapObject[2000];

            if(Main.LocalPlayer.GetModPlayer<SeamapPlayer>().myLastBoatPos == Vector2.Zero)
                localship = new SeamapPlayerShip(shipPos, Vector2.Zero, Main.LocalPlayer);
            else
                localship = new SeamapPlayerShip(Main.LocalPlayer.GetModPlayer<SeamapPlayer>().myLastBoatPos, Vector2.Zero, Main.LocalPlayer);

            NewSeamapObject(localship);
        }

        /// <summary>
        /// Adds the seamap object to the <see cref="SeamapEntities"/> array.
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NewSeamapObject(SeamapObject obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            for (int i = 0; i < SeamapEntities.Length; i++)
            {
                if (SeamapEntities[i] == null || !SeamapEntities[i].active)
                {
                    SeamapEntities[i] = obj;
                    obj.whoAmI = i;
                    obj.active = true;
                    obj.OnSpawn();

                    break;
                }
            }
        }

        public static void DestroyObject(SeamapObject obj)
        {
            int index = obj.whoAmI;
            if (index == -1) // already deleted or non existent
                return;

            obj.active = false;
            obj.whoAmI = -1;

            SeamapEntities[index] = null;
        }

        public struct ActiveEntitiesEnumerator 
        {
            int position;

            SeamapObject[] objects;

            public ref SeamapObject Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => ref SeamapEntities[position];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ActiveEntitiesEnumerator(SeamapObject[] objects)
            {
                position = -1;
                this.objects = objects;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                int index = position + 1;
                while (index < objects.Length)
                {
                    if (objects[index]?.active == true)
                    {
                        position = index;
                        return true;
                    }
                    index++;
                }
                position = objects.Length;
                return false;
            }

            public ActiveEntitiesEnumerator GetEnumerator() => this;
        }
    }
}
