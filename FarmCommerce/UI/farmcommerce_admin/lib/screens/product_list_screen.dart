import 'package:farmcommerce_admin/models/search_result.dart';
import 'package:farmcommerce_admin/providers/product_provider.dart';
import 'package:farmcommerce_admin/screens/product_detail_screen.dart';
import 'package:farmcommerce_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../models/product.dart';
import '../utils/util.dart';

class ProductListScreen extends StatefulWidget {
  const ProductListScreen({super.key});

  @override
  State<ProductListScreen> createState() => _ProductListScreenState();
}

class _ProductListScreenState extends State<ProductListScreen> {

  late ProductProvider _productProvider;

  SearchResult<Product>? result;
  TextEditingController _ftsController = TextEditingController();
  TextEditingController _sifraController = TextEditingController();


  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _productProvider = context.read<ProductProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title_widget: Text("Product list"),
      child: Container(
        child: Column(children: [_buildSearch(), _buildDataListView()]),
      ),
    );
  }

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Row(
        children: [
          Expanded(
            child: TextField(
              decoration: InputDecoration(labelText: "Naziv ili sifra"),
              controller: _ftsController,
            ),
          ),
          SizedBox(
            width: 8,
          ),
          Expanded(
            child: TextField(
              decoration: InputDecoration(labelText: "Šifra"),
              controller: _sifraController,
            ),
          ),
          ElevatedButton(
              onPressed: () async {
                print("login proceed");
                // Navigator.of(context).pop();

                var data = await _productProvider.get(filter: {
                  'fts': _ftsController.text,
                  'sifra': _sifraController.text
                });

                setState(() {
                  result = data;
                });

                // print("data: ${data.result[0].naziv}");
              },
              child: Text("Pretraga")),
          SizedBox(
            width: 8,
          ),
          ElevatedButton(
              onPressed: () async {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => ProductDetailScreen(
                      product: null,
                    ),
                  ),
                );
                // print("data: ${data.result[0].naziv}");
              },
              child: Text("Dodaj"))
        ],
      ),
    );
  }
  
   Widget _buildDataListView() {
    return Expanded(
        child: SingleChildScrollView(
      child: DataTable(

          columns: const [
            DataColumn(
              label: Expanded(
                child: Text(
                  'ID',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            DataColumn(
              label: Expanded(
                child: Text(
                  'Sifra',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            DataColumn(
              label: Expanded(
                child: Text(
                  'Naziv',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            DataColumn(
              label: Expanded(
                child: Text(
                  'Cijena',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            DataColumn(
              label: Expanded(
                child: Text(
                  'Firma',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            // const DataColumn(
            //   label: Expanded(
            //     child: Text(
            //       'Slika',
            //       style: TextStyle(fontStyle: FontStyle.italic),
            //     ),
            //   ),
            // )
          ],
          rows: result?.result
                  .map((Product e) => DataRow(
                          onSelectChanged: (selected) => {
                                if (selected == true)
                                  {
                                    Navigator.of(context).push(
                                      MaterialPageRoute(
                                        builder: (context) =>
                                            ProductDetailScreen(
                                          product: e,
                                        ),
                                      ),
                                    )
                                  }
                              },
                          cells: [
                            DataCell(Text(e.proizvodId?.toString() ?? "")),
                            DataCell(Text(e.naziv ?? "")),
                            DataCell(Text(e.opis ?? "")),
                            DataCell(Text(formatNumber(e.cena))),
                            DataCell(Text(e.firmaId?.toString() ?? "")),
                            // DataCell(e.slikaUrl != ""
                            //     ? Container(
                            //         width: 100,
                            //         height: 100,
                            //         child: imageFromBase64String(e.slikaUrl!),
                            //       )
                            //     : Text(""))
                          ]))
                  .toList() ??
              []),
    ));
  }
}