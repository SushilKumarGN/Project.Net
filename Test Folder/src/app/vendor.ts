// vendor.model.ts

export interface Vendor {
    vendorID: number;
    vendorLongName: string;
    vendorCode: string;
    vendorPhoneNumber: string;
    vendorEmail: string;
    vendorCreatedOn: string; // Assuming this is a string representation of DateTime
    isActive: boolean;
  }
  