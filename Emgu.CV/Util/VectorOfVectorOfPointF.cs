﻿//----------------------------------------------------------------------------
//
//  Copyright (C) 2004-2014 by EMGU Corporation. All rights reserved.
//
//  Vector of VectorOfPointF
//
//  This file is automatically generated, do not modify.
//----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Emgu.CV.Structure;

namespace Emgu.CV.Util
{
   /// <summary>
   /// Wraped class of the C++ standard vector of VectorOfPointF.
   /// </summary>
   public partial class VectorOfVectorOfPointF : Emgu.Util.UnmanagedObject, IInputOutputArray
   {
      private bool _needDispose;
   
      static VectorOfVectorOfPointF()
      {
         CvInvoke.CheckLibraryLoaded();
      }

      /// <summary>
      /// Create an empty standard vector of VectorOfPointF
      /// </summary>
      public VectorOfVectorOfPointF()
         : this(VectorOfVectorOfPointFCreate(), true)
      {
      }
	  
	  internal VectorOfVectorOfPointF(IntPtr ptr, bool needDispose)
      {
         _ptr = ptr;
         _needDispose = needDispose;
      }

      /// <summary>
      /// Create an standard vector of VectorOfPointF of the specific size
      /// </summary>
      /// <param name="size">The size of the vector</param>
      public VectorOfVectorOfPointF(int size)
         : this( VectorOfVectorOfPointFCreateSize(size), true)
      {
      }
	  
	  /// <summary>
      /// Create an standard vector of VectorOfPointF with the initial values
      /// </summary>
      /// <param name="values">The initial values</param>
	  public VectorOfVectorOfPointF(params VectorOfPointF[] values)
	     : this()
	  {
         foreach(VectorOfPointF v in values)
            Push(v);
	  }

      /// <summary>
      /// Get the size of the vector
      /// </summary>
      public int Size
      {
         get
         {
            return VectorOfVectorOfPointFGetSize(_ptr);
         }
      }

      /// <summary>
      /// Clear the vector
      /// </summary>
      public void Clear()
      {
         VectorOfVectorOfPointFClear(_ptr);
      }
	  
	  /// <summary>
      /// Push a value into the standard vector
      /// </summary>
      /// <param name="value">The value to be pushed to the vector</param>
      public void Push(VectorOfPointF value)
      {
         VectorOfVectorOfPointFPush(_ptr, value.Ptr);
      }

      /// <summary>
      /// Push multiple values into the standard vector
      /// </summary>
      /// <param name="values">The values to be pushed to the vector</param>
      public void Push(VectorOfPointF[] values)
      {
         foreach (VectorOfPointF value in values)
            Push(value);
      }
	  
	  /// <summary>
      /// Get the item in the specific index
      /// </summary>
      /// <param name="index">The index</param>
      /// <returns>The item in the specific index</returns>
      public VectorOfPointF this[int index]
      {
         get
         {
		    IntPtr itemPtr = IntPtr.Zero;
            VectorOfVectorOfPointFGetItemPtr(_ptr, index, ref itemPtr);
            return new VectorOfPointF(itemPtr, false);
         }
      }

      /// <summary>
      /// Release the standard vector
      /// </summary>
      protected override void DisposeObject()
      {
         if (_needDispose && _ptr != IntPtr.Zero)
            VectorOfVectorOfPointFRelease(ref _ptr);
      }

	  /// <summary>
      /// Get the pointer to cv::_InputArray
      /// </summary>
      public InputArray GetInputArray()
      {
        return new InputArray( cvInputArrayFromVectorOfVectorOfPointF(_ptr) );
      }
	  
      /// <summary>
      /// Get the pointer to cv::_OutputArray
      /// </summary>
      public OutputArray GetOutputArray()
      {
         return new OutputArray( cvOutputArrayFromVectorOfVectorOfPointF(_ptr) );
      }

	  /// <summary>
      /// Get the pointer to cv::_InputOutputArray
      /// </summary>
      public InputOutputArray GetInputOutputArray()
      {
         return new InputOutputArray( cvInputOutputArrayFromVectorOfVectorOfPointF(_ptr) );
      }

#if true
      /// <summary>
      /// Create the standard vector of VectorOfPointF 
      /// </summary>
      public VectorOfVectorOfPointF(PointF[][] values)
         : this()
      {
         using (VectorOfPointF v = new VectorOfPointF())
         {
            for (int i = 0; i < values.Length; i++)
            {
               v.Push(values[i]);
               Push(v);
               v.Clear();
            }
         }
      }
	  
	  /// <summary>
      /// Convert the standard vector to arrays of int
      /// </summary>
      /// <returns>Arrays of int</returns>
      public PointF[][] ToArrayOfArray()
      {
         int size = Size;
         PointF[][] res = new PointF[size][];
         for (int i = 0; i < size; i++)
         {
            using (VectorOfPointF v = this[i])
            {
               res[i] = v.ToArray();
            }
         }
         return res;
      }
#endif

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern IntPtr VectorOfVectorOfPointFCreate();

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern IntPtr VectorOfVectorOfPointFCreateSize(int size);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void VectorOfVectorOfPointFRelease(ref IntPtr v);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern int VectorOfVectorOfPointFGetSize(IntPtr v);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void VectorOfVectorOfPointFPush(IntPtr v, IntPtr value);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void VectorOfVectorOfPointFClear(IntPtr v);

	  [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void VectorOfVectorOfPointFGetItemPtr(IntPtr vec, int index, ref IntPtr element);
	  
      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern IntPtr cvInputArrayFromVectorOfVectorOfPointF(IntPtr vec);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern IntPtr cvOutputArrayFromVectorOfVectorOfPointF(IntPtr vec);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern IntPtr cvInputOutputArrayFromVectorOfVectorOfPointF(IntPtr vec);
   }
}
