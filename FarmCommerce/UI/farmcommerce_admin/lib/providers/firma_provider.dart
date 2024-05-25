import 'package:farmcommerce_admin/providers/base_provider.dart';
import '../models/firma.dart';

class FirmaProvider extends BaseProvider<Firma> {
  FirmaProvider(): super("Firma");

  @override
  Firma fromJson(data) {
    // TODO: implement fromJson
    return Firma.fromJson(data);
  }
}