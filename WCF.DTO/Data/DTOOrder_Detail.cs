using System; 
 
 namespace WCF.DTO.Data 
  {  
 public class DTOOrder_Detail
 { 
        public int OrderID {  get; set;  } 
        public int ProductID {  get; set;  } 
        public Decimal UnitPrice {  get; set;  } 
        public short Quantity {  get; set;  } 
        public float Discount {  get; set;  } 

 } 

 } 