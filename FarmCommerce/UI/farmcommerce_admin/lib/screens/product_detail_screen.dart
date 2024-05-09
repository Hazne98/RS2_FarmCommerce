import 'package:farmcommerce_admin/models/product.dart';
import 'package:farmcommerce_admin/widgets/master_screen.dart';
import 'package:flutter/cupertino.dart';

class ProductDetailScreen extends StatefulWidget {
  Product? product;
  ProductDetailScreen({super.key, this.product});

  @override
  State<ProductDetailScreen> createState() => _ProductDetailScreenState();
}

class _ProductDetailScreenState extends State<ProductDetailScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title: widget.product?.naziv ?? "Product details",
      child: Text("Details!"),
    );
  }
}