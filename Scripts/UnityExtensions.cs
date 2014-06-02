﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityHelpers
{
    public static class UnityExtensions
    {
        /// <summary>
        /// Checks to see if the game object has a component, accepts interfaces
        /// </summary>
        /// <typeparam name="T">Type of component to check for (can be an interface)</typeparam>
        /// <returns>Whether the object has the component</returns>
        public static bool Has<T>(this GameObject obj) where T : class
        {
            return obj.GetComponents<Component>().OfType<T>().FirstOrDefault() != null;
        }

        /// <summary>
        /// Gets a component on a game object, accepts interfaces
        /// </summary>
        /// <typeparam name="T">Type of component to check for (can be an interface)</typeparam>
        /// <param name="inObj"></param>
        /// <returns>The component, null if it doesnt exist</returns>
        public static T Get<T>(this GameObject obj) where T : class
        {
            return obj.GetComponents<Component>().OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Gets all components of a given type, accepts interfaces
        /// </summary>
        /// <typeparam name="T">Type of components to get (accepts interfaces)</typeparam>
        /// <returns>Enumerable of components</returns>
        public static IEnumerable<T> GetAll<T>(this GameObject obj) where T : class
        {
            return obj.GetComponents<Component>().OfType<T>();
        }

        /// <summary>
        /// Checks to see if the game object has a component, accepts interfaces
        /// </summary>
        /// <typeparam name="T">Type of component to check for (can be an interface)</typeparam>
        /// <returns>Whether the object has the component</returns>
        public static bool Has<T>(this Component component) where T : class
        {
            return Has<T>(component.gameObject);
        }

        /// <summary>
        /// Checks to see if the game object this component belongs to has a component, accepts interfaces
        /// </summary>
        /// <typeparam name="T">Type of component to check for (can be an interface)</typeparam>
        /// <returns>Whether the object has the component</returns>
        public static T Get<T>(this Component component) where T : class
        {
            return Get<T>(component.gameObject);
        }

        /// <summary>
        /// Gets all components of a given type, accepts interfaces
        /// </summary>
        /// <typeparam name="T">Type of components to get (accepts interfaces)</typeparam>
        /// <returns>Enumerable of components</returns>
        public static IEnumerable<T> GetAll<T>(this Component component) where T : class
        {
            return GetAll<T>(component.gameObject);
        }

        /// <summary>
        /// A shortcut for creating a new game object then adding a component then adding it to a parent object
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <returns>The new component</returns>
        public static T AddChild<T>(this GameObject parent) where T : Component
        {
            return AddChild<T>(parent, typeof(T).Name);
        }

        /// <summary>
        /// A shortcut for creating a new game object then adding a component then adding it to a parent object
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="name">Name of the child game object</param>
        /// <returns>The new component</returns>
        public static T AddChild<T>(this GameObject parent, string name) where T : Component
        {
            var obj = AddChild(parent, name, typeof(T));
            return obj.GetComponent<T>();
        }

        /// <summary>
        /// A shortcut for creating a new game object with a number of components and adding it as a child
        /// </summary>
        /// <param name="components">A list of component types</param>
        /// <returns>The new game object</returns>
        public static GameObject AddChild(this GameObject parent, params Type[] components)
        {
            return AddChild(parent, "Game Object", components);
        }

        /// <summary>
        /// A shortcut for creating a new game object with a number of components and adding it as a child
        /// </summary>
        /// <param name="name">The name of the new game object</param>
        /// <param name="components">A list of component types</param>
        /// <returns>The new game object</returns>
        public static GameObject AddChild(this GameObject parent, string name, params Type[] components)
        {
            var obj = new GameObject(name, components);
            if (parent != null) obj.transform.parent = parent.transform;
            return obj;
        }

        /// <summary>
        /// Focuses the camera on a point in 2D space (just transforms the x and y to match the target)
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="gameObject"></param>
        public static void FocusOn2D(this Camera camera, GameObject target)
        {
            camera.transform.position = new Vector3(target.transform.localPosition.x, target.transform.localPosition.y, Camera.main.transform.position.z);
        }
    }
}
