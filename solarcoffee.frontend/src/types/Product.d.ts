// d means it's a declaration file. Represents the shape of type. No business logic. Define interface here.
export interface IProductInventory {
    id: number;
    product: IProduct;
    quantityOnHand: number;
    idealQuantity: number;
}

export interface IProduct {
    id: number;
    createdOn: Date;
    updatedOn: Date;
    name: string;
    description: string;
    price: number;
    isTaxable: boolean;
    isArchived: boolean;
}

