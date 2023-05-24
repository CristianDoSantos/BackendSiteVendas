using FluentMigrator;

namespace BackendSiteVendas.Infrastructure.Migrations.Versions;
[Migration((long)VersionsNumber.CreateRemainingTables, "Create remaning table")]
public class Version0000002 : Migration
{
    public override void Down()
    {
        Delete.Table("Products");
        Delete.Table("Orders");
        Delete.Table("OrderItems");
        Delete.Table("ShoppingCartItems");
        Delete.Table("Categories");
        Delete.Table("ProductReviews");
    }

    public override void Up()
    {
        CreateCategoriesTable();
        CreateProductsTable();
        CreateOrdersTable();
        CreateOrderItemsTable();
        CreateShoppingCartItemsTable();
        CreateProductReviewsTable();
    }

    private void CreateProductsTable()
    {
        var productsTable = VersionBase.InsertDefaultColumns(Create.Table("Products"));

        productsTable
            .WithColumn("Name").AsString(500).NotNullable()
            .WithColumn("Description").AsString().Nullable()
            .WithColumn("Price").AsDecimal(10, 2).NotNullable()
            .WithColumn("StockQuantity").AsInt32().NotNullable()
            .WithColumn("CategoryId").AsInt64().Nullable()
            .ForeignKey("FK_Products_Categories", "Categories", "Id")
            .WithColumn("Brand").AsString(100).Nullable()
            .WithColumn("Image").AsString(300).Nullable()
            .WithColumn("UpdateDate").AsDateTime().Nullable()
            .WithColumn("Emphasis").AsBoolean().WithDefaultValue(false)
            .WithColumn("Active").AsBoolean().WithDefaultValue(true)
            .WithColumn("Weight").AsDecimal(10, 2).Nullable()
            .WithColumn("Length").AsDecimal(10, 2).Nullable()
            .WithColumn("Width").AsDecimal(10, 2).Nullable()
            .WithColumn("Height").AsDecimal(10, 2).Nullable();
    }

    private void CreateOrdersTable()
    {
        var ordersTable = VersionBase.InsertDefaultColumns(Create.Table("Orders"));

        ordersTable
          .WithColumn("UserId").AsInt64().NotNullable()
          .ForeignKey("FK_Orders_Users", "Users", "Id")
          .WithColumn("OrderDate").AsDateTime().NotNullable()
          .WithColumn("Status").AsString(20).NotNullable()
          .WithColumn("PaymentInfo").AsString(200).NotNullable()
          .WithColumn("DeliveryAddress").AsString(500).NotNullable();
    }

    private void CreateOrderItemsTable()
    {
        var orderItemsTable = VersionBase.InsertDefaultColumns(Create.Table("OrderItems"));

        orderItemsTable
            .WithColumn("OrderId").AsInt64().NotNullable()
            .ForeignKey("FK_OrderItems_Orders", "Orders", "Id")
            .WithColumn("ProductId").AsInt64().NotNullable()
            .ForeignKey("FK_OrderItems_Products", "Products", "Id")
            .WithColumn("Quantity").AsInt32().NotNullable()
            .WithColumn("UnitPrice").AsDecimal(10, 2).NotNullable();
    }

    private void CreateShoppingCartItemsTable()
    {
        var shoppingCartItems = VersionBase.InsertDefaultColumns(Create.Table("ShoppingCartItems"));

        shoppingCartItems
            .WithColumn("UserId").AsInt64().NotNullable()
            .ForeignKey("FK_ShoppingCartItems_Users", "Users", "Id")
            .WithColumn("ProductId").AsInt64().NotNullable()
            .ForeignKey("FK_ShoppingCartItems_Products", "Products", "Id")
            .WithColumn("Quantity").AsInt32().NotNullable();
    }

    private void CreateCategoriesTable()
    {
        var categories = VersionBase.InsertDefaultColumns(Create.Table("Categories"));

        categories
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Description").AsString(500).Nullable();
    }

    private void CreateProductReviewsTable()
    {
        var productReviews = VersionBase.InsertDefaultColumns(Create.Table("ProductReviews"));

        productReviews
            .WithColumn("UserId").AsInt64().NotNullable()
            .ForeignKey("FK_ProductReviews_Users", "Users", "Id")
            .WithColumn("ProductId").AsInt64().NotNullable()
            .ForeignKey("FK_ProductReviews_Products", "Products", "Id")
            .WithColumn("Rating").AsInt32().NotNullable()
            .WithColumn("Comments").AsString(1000).NotNullable();
    }
}
