import 'package:farmcommerce_admin/models/product.dart';
import 'package:farmcommerce_admin/providers/base_provider.dart';

class ProductProvider extends BaseProvider<Product> {
  ProductProvider():super("Proizvodi");

  @override
  Product fromJson(data) {
    // TODO: implement fromJson
    return Product.fromJson(data);
  }
}