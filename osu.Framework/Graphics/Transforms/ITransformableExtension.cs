﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Framework.Graphics.Transforms
{
    public static class ITransformableExtension
    {
        /// <summary>
        /// Applies a transform to this object.
        /// </summary>
        /// <typeparam name="TValue">The value type upon which the transform acts.</typeparam>
        /// <param name="newValue">The value to transform to.</param>
        /// <param name="duration">The transform duration.</param>
        /// <param name="easing">The transform easing.</param>
        /// <param name="transform">The transform to use.</param>
        public static TransformContinuation<TThis> TransformTo<TThis, TValue, TBase>(
            this TThis t, TValue newValue, double duration, EasingTypes easing, Transform<TValue, TBase> transform)
            where TThis : ITransformable, TBase
        {
            double startTime = t.TransformStartTime;

            transform.StartTime = startTime;
            transform.EndTime = startTime + duration;
            transform.EndValue = newValue;
            transform.Easing = easing;

            t.AddTransform(transform);
            return new TransformContinuation<TThis>(t, transform);
        }


    }
}
