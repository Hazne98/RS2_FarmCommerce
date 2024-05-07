import 'package:farmcommerce_admin/widgets/master_screen.dart';
import 'package:flutter/cupertino.dart';

class ProductDetailScreen extends StatefulWidget {
  const ProductDetailScreen({super.key});

  @override
  State<ProductDetailScreen> createState() => _ProductDetailScreenState();
}

class _ProductDetailScreenState extends State<ProductDetailScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title: "Product details",
      child: Text("Details!"),
    );
  }
}