import 'package:farmcommerce_admin/models/product.dart';
import 'package:farmcommerce_admin/widgets/master_screen.dart';
import 'package:farmcommerce_admin/models/firma.dart';
import 'package:farmcommerce_admin/providers/product_provider.dart';
import 'package:farmcommerce_admin/providers/firma_provider.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import '../models/search_result.dart';
import 'dart:convert';
import 'dart:io';

class ProductDetailScreen extends StatefulWidget {
  Product? product;
  ProductDetailScreen({super.key, this.product});

  @override
  State<ProductDetailScreen> createState() => _ProductDetailScreenState();
}

class _ProductDetailScreenState extends State<ProductDetailScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  late FirmaProvider _firmaProvider;
  late ProductProvider _productProvider;

  SearchResult<Firma>? firmaResult;
  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    _initialValue = {
      'naziv': widget.product?.naziv,
      'opis': widget.product?.opis,
      'firmaId': widget.product?.firmaId?.toString(),
      'cena': widget.product?.cena?.toString(),
    };

    _firmaProvider = context.read<FirmaProvider>();
    _productProvider = context.read<ProductProvider>();

    initForm();
  }

  Future<void> initForm() async {
    try {
      firmaResult = await _firmaProvider.get();
      setState(() {
        isLoading = false;
      });
    } catch (e, stackTrace) {
      print("Error in initForm: $e");
      print(stackTrace);
      setState(() {
        isLoading = false;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title: this.widget.product?.naziv ?? "Product details",
      child: Column(
        children: [
          isLoading ? Container() : _buildForm(),
          Row(
            mainAxisAlignment: MainAxisAlignment.end,
            children: [
               Padding(
                padding: EdgeInsets.all(10),
                child: ElevatedButton(
                    onPressed: () async {
                      _formKey.currentState?.saveAndValidate();

                      print(_formKey.currentState?.value);
                      print(_formKey.currentState?.value['naziv']);

                      var request = new Map.from(_formKey.currentState!.value);

                      request['slika'] = _base64Image;

                      print(request['slika']);

                      try {
                        if (widget.product == null) {
                          await _productProvider
                              .insert(request);
                        } else {
                          await _productProvider.update(
                              widget.product!.proizvodId!,
                              request);
                        }
                      } on Exception catch (e) {
                      showDialog(
                        context: context,
                        builder: (BuildContext context) => AlertDialog(
                          title: Text("Error"),
                          content: Text(e.toString()),
                          actions: [
                            TextButton(
                              onPressed: () => Navigator.pop(context),
                              child: Text("OK"),
                            ),
                          ],
                        ),
                      );
                    }
                  },
                  child: Text("Sačuvaj"),
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }

  FormBuilder _buildForm() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Column(
        children: [
          Row(
            children: [
              Expanded(
                child: FormBuilderTextField(
                  decoration: InputDecoration(labelText: "Opis"),
                  name: "opis",
                ),
              ),
              SizedBox(width: 10),
              Expanded(
                child: FormBuilderTextField(
                  decoration: InputDecoration(labelText: "Naziv"),
                  name: "naziv",
                ),
              ),
            ],
          ),
          Row(
            children: [
              Expanded(
                child: FormBuilderDropdown<String>(
                  name: 'firmaId',
                  decoration: InputDecoration(
                    labelText: 'Firma',
                    suffix: IconButton(
                      icon: const Icon(Icons.close),
                      onPressed: () {
                        _formKey.currentState!.fields['firmaId']?.reset();
                      },
                    ),
                    hintText: 'Select Firma',
                  ),
                  items: firmaResult?.result
                      .map((item) => DropdownMenuItem(
                            alignment: AlignmentDirectional.center,
                            value: item.firmaId?.toString(),
                            child: Text(item.naziv ?? ""),
                          ))
                      .toList() ?? [],
                ),
              ),
              SizedBox(width: 10),
              Expanded(
                child: FormBuilderTextField(
                  decoration: InputDecoration(labelText: "Cena"),
                  name: "cena",
                ),
              ),
            ],
            ),
        Row(
          children: [
            Expanded(
                child: FormBuilderField(
              name: 'imageId',
              builder: ((field) {
                return InputDecorator(
                  decoration: InputDecoration(
                      label: Text('Odaberite sliku'),
                      errorText: field.errorText),
                  child: ListTile(
                    leading: Icon(Icons.photo),
                    title: Text("Select image"),
                    trailing: Icon(Icons.file_upload),
                    onTap: getImage,
                  ),
                );
              }),
            ))
          ],
        )
      ]),
    );
  }
  File? _image;
  String? _base64Image;

  Future getImage()  async {
    var result = await FilePicker.platform.pickFiles(type: FileType.image);

    if(result != null && result.files.single.path != null) {
      _image = File(result.files.single.path!);
      _base64Image = base64Encode(_image!.readAsBytesSync());
    }

  }
}
