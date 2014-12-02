//----------------------------------------------------------------------------
//  Copyright (C) 2004-2014 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.ServiceModel;
using Emgu.CV.Structure;

namespace Emgu.CV
{
   ///<summary> The interface that is used for WCF to provide a image capture service</summary>
   [XmlSerializerFormat]
   [ServiceContract]
   public interface ICapture
   {
      ///<summary> Capture a Bgr image frame </summary>
      ///<returns> A Bgr image frame</returns>
      [OperationContract]
      Mat QueryFrame();

      ///<summary> Capture a Bgr image frame that is half width and half heigh</summary>
      ///<returns> A Bgr image frame that is half width and half height</returns>
      [OperationContract]
      Mat QuerySmallFrame();
   }
}
