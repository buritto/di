﻿using System;
using System.Collections.Generic;

namespace TagCloud
{
    public struct Result<T>
    {
        public string ErrorMessage { get; }
        public  T Value { get; }

        public Result(string errorMessage, T value = default(T))
        {
            ErrorMessage = errorMessage;
            Value = value;
        }

        public bool IsSuccess => ErrorMessage == null;

        public T TryGetValue()
        {
            if (IsSuccess)
                return Value;
            throw new InvalidOperationException(ErrorMessage);
        }
    }


    public static class Result
    {
        public static Result<T> AsResult<T>(this T value)
        {
            return new Result<T>(null, value);
        }

        public static Result<T> Fail<T>(string errorMessage)
        {
            return new Result<T>(errorMessage);
        }

        public static Result<T> Of<T>(Func<T> func, string messageError = null)
        {
            try
            {
                return new Result<T>(null, func());
            }
            catch (Exception e)
            {
                return new Result<T>(messageError ?? e.Message);
            }
        }

        public static Result<TOutput> Then<TInput, TOutput>(this Result<TInput> input,
            Func<TInput, Result<TOutput>> continuation)
        {
            return input.IsSuccess
                ? continuation(input.Value)
                : Fail<TOutput>(input.ErrorMessage);
        }
    }
}
