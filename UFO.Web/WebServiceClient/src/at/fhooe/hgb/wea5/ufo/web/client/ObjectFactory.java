
package at.fhooe.hgb.wea5.ufo.web.client;

import java.math.BigDecimal;
import java.math.BigInteger;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.datatype.Duration;
import javax.xml.datatype.XMLGregorianCalendar;
import javax.xml.namespace.QName;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the at.fhooe.hgb.wea5.ufo.web.client package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _UnsignedLong_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "unsignedLong");
    private final static QName _UnsignedByte_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "unsignedByte");
    private final static QName _Venue_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "Venue");
    private final static QName _UnsignedShort_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "unsignedShort");
    private final static QName _Duration_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "duration");
    private final static QName _Long_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "long");
    private final static QName _Float_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "float");
    private final static QName _DomainObject_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "DomainObject");
    private final static QName _Country_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "Country");
    private final static QName _DateTime_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "dateTime");
    private final static QName _Performance_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "Performance");
    private final static QName _AnyType_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "anyType");
    private final static QName _String_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "string");
    private final static QName _Location_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "Location");
    private final static QName _Artist_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "Artist");
    private final static QName _UnsignedInt_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "unsignedInt");
    private final static QName _Char_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "char");
    private final static QName _Category_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "Category");
    private final static QName _Short_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "short");
    private final static QName _Guid_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "guid");
    private final static QName _Decimal_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "decimal");
    private final static QName _ArrayOfCategory_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "ArrayOfCategory");
    private final static QName _Boolean_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "boolean");
    private final static QName _ArrayOfCountry_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "ArrayOfCountry");
    private final static QName _Base64Binary_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "base64Binary");
    private final static QName _ArrayOfArtist_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "ArrayOfArtist");
    private final static QName _Int_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "int");
    private final static QName _ArrayOfVenue_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "ArrayOfVenue");
    private final static QName _AnyURI_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "anyURI");
    private final static QName _ArrayOfLocation_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "ArrayOfLocation");
    private final static QName _BlobData_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "BlobData");
    private final static QName _Byte_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "byte");
    private final static QName _Double_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "double");
    private final static QName _QName_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "QName");
    private final static QName _PagingData_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "PagingData");
    private final static QName _ArrayOfPerformance_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "ArrayOfPerformance");
    private final static QName _RequestPerformancePagingDataResponseRequestPerformancePagingDataResult_QNAME = new QName("http://tempuri.org/", "RequestPerformancePagingDataResult");
    private final static QName _GetCountriesResponseGetCountriesResult_QNAME = new QName("http://tempuri.org/", "GetCountriesResult");
    private final static QName _RequestArtistPagingDataResponseRequestArtistPagingDataResult_QNAME = new QName("http://tempuri.org/", "RequestArtistPagingDataResult");
    private final static QName _GetPerformancesResponseGetPerformancesResult_QNAME = new QName("http://tempuri.org/", "GetPerformancesResult");
    private final static QName _RequestCountryPagingDataResponseRequestCountryPagingDataResult_QNAME = new QName("http://tempuri.org/", "RequestCountryPagingDataResult");
    private final static QName _CountryCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "Code");
    private final static QName _CountryName_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "Name");
    private final static QName _RequestLocationPagingDataResponseRequestLocationPagingDataResult_QNAME = new QName("http://tempuri.org/", "RequestLocationPagingDataResult");
    private final static QName _GetCategoriesPage_QNAME = new QName("http://tempuri.org/", "page");
    private final static QName _CategoryCategoryId_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "CategoryId");
    private final static QName _CategoryColor_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "Color");
    private final static QName _VenueVenueId_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "VenueId");
    private final static QName _ArtistPromoVideo_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "PromoVideo");
    private final static QName _ArtistPicture_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "Picture");
    private final static QName _ArtistEMail_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "EMail");
    private final static QName _GetLocationsResponseGetLocationsResult_QNAME = new QName("http://tempuri.org/", "GetLocationsResult");
    private final static QName _RequestVenuePagingDataResponseRequestVenuePagingDataResult_QNAME = new QName("http://tempuri.org/", "RequestVenuePagingDataResult");
    private final static QName _GetPerformancesPerDateResponseGetPerformancesPerDateResult_QNAME = new QName("http://tempuri.org/", "GetPerformancesPerDateResult");
    private final static QName _GetArtistResponseGetArtistResult_QNAME = new QName("http://tempuri.org/", "GetArtistResult");
    private final static QName _RequestCategoryPagingDataResponseRequestCategoryPagingDataResult_QNAME = new QName("http://tempuri.org/", "RequestCategoryPagingDataResult");
    private final static QName _GetCategoriesResponseGetCategoriesResult_QNAME = new QName("http://tempuri.org/", "GetCategoriesResult");
    private final static QName _BlobDataPath_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "Path");
    private final static QName _BlobDataDataStream_QNAME = new QName("http://schemas.datacontract.org/2004/07/UFO.Server.Domain", "DataStream");
    private final static QName _GetVenuesResponseGetVenuesResult_QNAME = new QName("http://tempuri.org/", "GetVenuesResult");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: at.fhooe.hgb.wea5.ufo.web.client
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link GetCountries }
     * 
     */
    public GetCountries createGetCountries() {
        return new GetCountries();
    }

    /**
     * Create an instance of {@link PagingData }
     * 
     */
    public PagingData createPagingData() {
        return new PagingData();
    }

    /**
     * Create an instance of {@link GetPerformancesPerDate }
     * 
     */
    public GetPerformancesPerDate createGetPerformancesPerDate() {
        return new GetPerformancesPerDate();
    }

    /**
     * Create an instance of {@link RequestCategoryPagingDataResponse }
     * 
     */
    public RequestCategoryPagingDataResponse createRequestCategoryPagingDataResponse() {
        return new RequestCategoryPagingDataResponse();
    }

    /**
     * Create an instance of {@link RequestPerformancePagingDataResponse }
     * 
     */
    public RequestPerformancePagingDataResponse createRequestPerformancePagingDataResponse() {
        return new RequestPerformancePagingDataResponse();
    }

    /**
     * Create an instance of {@link GetArtist }
     * 
     */
    public GetArtist createGetArtist() {
        return new GetArtist();
    }

    /**
     * Create an instance of {@link GetVenues }
     * 
     */
    public GetVenues createGetVenues() {
        return new GetVenues();
    }

    /**
     * Create an instance of {@link RequestArtistPagingDataResponse }
     * 
     */
    public RequestArtistPagingDataResponse createRequestArtistPagingDataResponse() {
        return new RequestArtistPagingDataResponse();
    }

    /**
     * Create an instance of {@link GetCategories }
     * 
     */
    public GetCategories createGetCategories() {
        return new GetCategories();
    }

    /**
     * Create an instance of {@link GetLocations }
     * 
     */
    public GetLocations createGetLocations() {
        return new GetLocations();
    }

    /**
     * Create an instance of {@link RequestLocationPagingDataResponse }
     * 
     */
    public RequestLocationPagingDataResponse createRequestLocationPagingDataResponse() {
        return new RequestLocationPagingDataResponse();
    }

    /**
     * Create an instance of {@link RequestCountryPagingData }
     * 
     */
    public RequestCountryPagingData createRequestCountryPagingData() {
        return new RequestCountryPagingData();
    }

    /**
     * Create an instance of {@link GetLocationsResponse }
     * 
     */
    public GetLocationsResponse createGetLocationsResponse() {
        return new GetLocationsResponse();
    }

    /**
     * Create an instance of {@link ArrayOfLocation }
     * 
     */
    public ArrayOfLocation createArrayOfLocation() {
        return new ArrayOfLocation();
    }

    /**
     * Create an instance of {@link RequestArtistPagingData }
     * 
     */
    public RequestArtistPagingData createRequestArtistPagingData() {
        return new RequestArtistPagingData();
    }

    /**
     * Create an instance of {@link GetArtistResponse }
     * 
     */
    public GetArtistResponse createGetArtistResponse() {
        return new GetArtistResponse();
    }

    /**
     * Create an instance of {@link ArrayOfArtist }
     * 
     */
    public ArrayOfArtist createArrayOfArtist() {
        return new ArrayOfArtist();
    }

    /**
     * Create an instance of {@link GetPerformancesResponse }
     * 
     */
    public GetPerformancesResponse createGetPerformancesResponse() {
        return new GetPerformancesResponse();
    }

    /**
     * Create an instance of {@link ArrayOfPerformance }
     * 
     */
    public ArrayOfPerformance createArrayOfPerformance() {
        return new ArrayOfPerformance();
    }

    /**
     * Create an instance of {@link GetPerformancesPerDateResponse }
     * 
     */
    public GetPerformancesPerDateResponse createGetPerformancesPerDateResponse() {
        return new GetPerformancesPerDateResponse();
    }

    /**
     * Create an instance of {@link GetCountriesResponse }
     * 
     */
    public GetCountriesResponse createGetCountriesResponse() {
        return new GetCountriesResponse();
    }

    /**
     * Create an instance of {@link ArrayOfCountry }
     * 
     */
    public ArrayOfCountry createArrayOfCountry() {
        return new ArrayOfCountry();
    }

    /**
     * Create an instance of {@link RequestVenuePagingDataResponse }
     * 
     */
    public RequestVenuePagingDataResponse createRequestVenuePagingDataResponse() {
        return new RequestVenuePagingDataResponse();
    }

    /**
     * Create an instance of {@link RequestCategoryPagingData }
     * 
     */
    public RequestCategoryPagingData createRequestCategoryPagingData() {
        return new RequestCategoryPagingData();
    }

    /**
     * Create an instance of {@link RequestLocationPagingData }
     * 
     */
    public RequestLocationPagingData createRequestLocationPagingData() {
        return new RequestLocationPagingData();
    }

    /**
     * Create an instance of {@link GetVenuesResponse }
     * 
     */
    public GetVenuesResponse createGetVenuesResponse() {
        return new GetVenuesResponse();
    }

    /**
     * Create an instance of {@link ArrayOfVenue }
     * 
     */
    public ArrayOfVenue createArrayOfVenue() {
        return new ArrayOfVenue();
    }

    /**
     * Create an instance of {@link RequestVenuePagingData }
     * 
     */
    public RequestVenuePagingData createRequestVenuePagingData() {
        return new RequestVenuePagingData();
    }

    /**
     * Create an instance of {@link RequestCountryPagingDataResponse }
     * 
     */
    public RequestCountryPagingDataResponse createRequestCountryPagingDataResponse() {
        return new RequestCountryPagingDataResponse();
    }

    /**
     * Create an instance of {@link RequestPerformancePagingData }
     * 
     */
    public RequestPerformancePagingData createRequestPerformancePagingData() {
        return new RequestPerformancePagingData();
    }

    /**
     * Create an instance of {@link GetPerformances }
     * 
     */
    public GetPerformances createGetPerformances() {
        return new GetPerformances();
    }

    /**
     * Create an instance of {@link GetCategoriesResponse }
     * 
     */
    public GetCategoriesResponse createGetCategoriesResponse() {
        return new GetCategoriesResponse();
    }

    /**
     * Create an instance of {@link ArrayOfCategory }
     * 
     */
    public ArrayOfCategory createArrayOfCategory() {
        return new ArrayOfCategory();
    }

    /**
     * Create an instance of {@link Artist }
     * 
     */
    public Artist createArtist() {
        return new Artist();
    }

    /**
     * Create an instance of {@link Category }
     * 
     */
    public Category createCategory() {
        return new Category();
    }

    /**
     * Create an instance of {@link Venue }
     * 
     */
    public Venue createVenue() {
        return new Venue();
    }

    /**
     * Create an instance of {@link DomainObject }
     * 
     */
    public DomainObject createDomainObject() {
        return new DomainObject();
    }

    /**
     * Create an instance of {@link Country }
     * 
     */
    public Country createCountry() {
        return new Country();
    }

    /**
     * Create an instance of {@link BlobData }
     * 
     */
    public BlobData createBlobData() {
        return new BlobData();
    }

    /**
     * Create an instance of {@link Performance }
     * 
     */
    public Performance createPerformance() {
        return new Performance();
    }

    /**
     * Create an instance of {@link Location }
     * 
     */
    public Location createLocation() {
        return new Location();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link BigInteger }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "unsignedLong")
    public JAXBElement<BigInteger> createUnsignedLong(BigInteger value) {
        return new JAXBElement<BigInteger>(_UnsignedLong_QNAME, BigInteger.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Short }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "unsignedByte")
    public JAXBElement<Short> createUnsignedByte(Short value) {
        return new JAXBElement<Short>(_UnsignedByte_QNAME, Short.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Venue }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Venue")
    public JAXBElement<Venue> createVenue(Venue value) {
        return new JAXBElement<Venue>(_Venue_QNAME, Venue.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Integer }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "unsignedShort")
    public JAXBElement<Integer> createUnsignedShort(Integer value) {
        return new JAXBElement<Integer>(_UnsignedShort_QNAME, Integer.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Duration }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "duration")
    public JAXBElement<Duration> createDuration(Duration value) {
        return new JAXBElement<Duration>(_Duration_QNAME, Duration.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Long }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "long")
    public JAXBElement<Long> createLong(Long value) {
        return new JAXBElement<Long>(_Long_QNAME, Long.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Float }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "float")
    public JAXBElement<Float> createFloat(Float value) {
        return new JAXBElement<Float>(_Float_QNAME, Float.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link DomainObject }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "DomainObject")
    public JAXBElement<DomainObject> createDomainObject(DomainObject value) {
        return new JAXBElement<DomainObject>(_DomainObject_QNAME, DomainObject.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Country }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Country")
    public JAXBElement<Country> createCountry(Country value) {
        return new JAXBElement<Country>(_Country_QNAME, Country.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link XMLGregorianCalendar }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "dateTime")
    public JAXBElement<XMLGregorianCalendar> createDateTime(XMLGregorianCalendar value) {
        return new JAXBElement<XMLGregorianCalendar>(_DateTime_QNAME, XMLGregorianCalendar.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Performance }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Performance")
    public JAXBElement<Performance> createPerformance(Performance value) {
        return new JAXBElement<Performance>(_Performance_QNAME, Performance.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Object }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "anyType")
    public JAXBElement<Object> createAnyType(Object value) {
        return new JAXBElement<Object>(_AnyType_QNAME, Object.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "string")
    public JAXBElement<String> createString(String value) {
        return new JAXBElement<String>(_String_QNAME, String.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Location }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Location")
    public JAXBElement<Location> createLocation(Location value) {
        return new JAXBElement<Location>(_Location_QNAME, Location.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Artist }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Artist")
    public JAXBElement<Artist> createArtist(Artist value) {
        return new JAXBElement<Artist>(_Artist_QNAME, Artist.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Long }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "unsignedInt")
    public JAXBElement<Long> createUnsignedInt(Long value) {
        return new JAXBElement<Long>(_UnsignedInt_QNAME, Long.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Integer }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "char")
    public JAXBElement<Integer> createChar(Integer value) {
        return new JAXBElement<Integer>(_Char_QNAME, Integer.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Category }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Category")
    public JAXBElement<Category> createCategory(Category value) {
        return new JAXBElement<Category>(_Category_QNAME, Category.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Short }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "short")
    public JAXBElement<Short> createShort(Short value) {
        return new JAXBElement<Short>(_Short_QNAME, Short.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "guid")
    public JAXBElement<String> createGuid(String value) {
        return new JAXBElement<String>(_Guid_QNAME, String.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link BigDecimal }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "decimal")
    public JAXBElement<BigDecimal> createDecimal(BigDecimal value) {
        return new JAXBElement<BigDecimal>(_Decimal_QNAME, BigDecimal.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfCategory }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "ArrayOfCategory")
    public JAXBElement<ArrayOfCategory> createArrayOfCategory(ArrayOfCategory value) {
        return new JAXBElement<ArrayOfCategory>(_ArrayOfCategory_QNAME, ArrayOfCategory.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Boolean }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "boolean")
    public JAXBElement<Boolean> createBoolean(Boolean value) {
        return new JAXBElement<Boolean>(_Boolean_QNAME, Boolean.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfCountry }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "ArrayOfCountry")
    public JAXBElement<ArrayOfCountry> createArrayOfCountry(ArrayOfCountry value) {
        return new JAXBElement<ArrayOfCountry>(_ArrayOfCountry_QNAME, ArrayOfCountry.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link byte[]}{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "base64Binary")
    public JAXBElement<byte[]> createBase64Binary(byte[] value) {
        return new JAXBElement<byte[]>(_Base64Binary_QNAME, byte[].class, null, ((byte[]) value));
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfArtist }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "ArrayOfArtist")
    public JAXBElement<ArrayOfArtist> createArrayOfArtist(ArrayOfArtist value) {
        return new JAXBElement<ArrayOfArtist>(_ArrayOfArtist_QNAME, ArrayOfArtist.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Integer }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "int")
    public JAXBElement<Integer> createInt(Integer value) {
        return new JAXBElement<Integer>(_Int_QNAME, Integer.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfVenue }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "ArrayOfVenue")
    public JAXBElement<ArrayOfVenue> createArrayOfVenue(ArrayOfVenue value) {
        return new JAXBElement<ArrayOfVenue>(_ArrayOfVenue_QNAME, ArrayOfVenue.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "anyURI")
    public JAXBElement<String> createAnyURI(String value) {
        return new JAXBElement<String>(_AnyURI_QNAME, String.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfLocation }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "ArrayOfLocation")
    public JAXBElement<ArrayOfLocation> createArrayOfLocation(ArrayOfLocation value) {
        return new JAXBElement<ArrayOfLocation>(_ArrayOfLocation_QNAME, ArrayOfLocation.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link BlobData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "BlobData")
    public JAXBElement<BlobData> createBlobData(BlobData value) {
        return new JAXBElement<BlobData>(_BlobData_QNAME, BlobData.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Byte }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "byte")
    public JAXBElement<Byte> createByte(Byte value) {
        return new JAXBElement<Byte>(_Byte_QNAME, Byte.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Double }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "double")
    public JAXBElement<Double> createDouble(Double value) {
        return new JAXBElement<Double>(_Double_QNAME, Double.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link QName }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.microsoft.com/2003/10/Serialization/", name = "QName")
    public JAXBElement<QName> createQName(QName value) {
        return new JAXBElement<QName>(_QName_QNAME, QName.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "PagingData")
    public JAXBElement<PagingData> createPagingData(PagingData value) {
        return new JAXBElement<PagingData>(_PagingData_QNAME, PagingData.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfPerformance }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "ArrayOfPerformance")
    public JAXBElement<ArrayOfPerformance> createArrayOfPerformance(ArrayOfPerformance value) {
        return new JAXBElement<ArrayOfPerformance>(_ArrayOfPerformance_QNAME, ArrayOfPerformance.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "RequestPerformancePagingDataResult", scope = RequestPerformancePagingDataResponse.class)
    public JAXBElement<PagingData> createRequestPerformancePagingDataResponseRequestPerformancePagingDataResult(PagingData value) {
        return new JAXBElement<PagingData>(_RequestPerformancePagingDataResponseRequestPerformancePagingDataResult_QNAME, PagingData.class, RequestPerformancePagingDataResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfCountry }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "GetCountriesResult", scope = GetCountriesResponse.class)
    public JAXBElement<ArrayOfCountry> createGetCountriesResponseGetCountriesResult(ArrayOfCountry value) {
        return new JAXBElement<ArrayOfCountry>(_GetCountriesResponseGetCountriesResult_QNAME, ArrayOfCountry.class, GetCountriesResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "RequestArtistPagingDataResult", scope = RequestArtistPagingDataResponse.class)
    public JAXBElement<PagingData> createRequestArtistPagingDataResponseRequestArtistPagingDataResult(PagingData value) {
        return new JAXBElement<PagingData>(_RequestArtistPagingDataResponseRequestArtistPagingDataResult_QNAME, PagingData.class, RequestArtistPagingDataResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfPerformance }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "GetPerformancesResult", scope = GetPerformancesResponse.class)
    public JAXBElement<ArrayOfPerformance> createGetPerformancesResponseGetPerformancesResult(ArrayOfPerformance value) {
        return new JAXBElement<ArrayOfPerformance>(_GetPerformancesResponseGetPerformancesResult_QNAME, ArrayOfPerformance.class, GetPerformancesResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "RequestCountryPagingDataResult", scope = RequestCountryPagingDataResponse.class)
    public JAXBElement<PagingData> createRequestCountryPagingDataResponseRequestCountryPagingDataResult(PagingData value) {
        return new JAXBElement<PagingData>(_RequestCountryPagingDataResponseRequestCountryPagingDataResult_QNAME, PagingData.class, RequestCountryPagingDataResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Code", scope = Country.class)
    public JAXBElement<String> createCountryCode(String value) {
        return new JAXBElement<String>(_CountryCode_QNAME, String.class, Country.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Name", scope = Country.class)
    public JAXBElement<String> createCountryName(String value) {
        return new JAXBElement<String>(_CountryName_QNAME, String.class, Country.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "RequestLocationPagingDataResult", scope = RequestLocationPagingDataResponse.class)
    public JAXBElement<PagingData> createRequestLocationPagingDataResponseRequestLocationPagingDataResult(PagingData value) {
        return new JAXBElement<PagingData>(_RequestLocationPagingDataResponseRequestLocationPagingDataResult_QNAME, PagingData.class, RequestLocationPagingDataResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "page", scope = GetCategories.class)
    public JAXBElement<PagingData> createGetCategoriesPage(PagingData value) {
        return new JAXBElement<PagingData>(_GetCategoriesPage_QNAME, PagingData.class, GetCategories.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "page", scope = GetCountries.class)
    public JAXBElement<PagingData> createGetCountriesPage(PagingData value) {
        return new JAXBElement<PagingData>(_GetCategoriesPage_QNAME, PagingData.class, GetCountries.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "page", scope = GetVenues.class)
    public JAXBElement<PagingData> createGetVenuesPage(PagingData value) {
        return new JAXBElement<PagingData>(_GetCategoriesPage_QNAME, PagingData.class, GetVenues.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "CategoryId", scope = Category.class)
    public JAXBElement<String> createCategoryCategoryId(String value) {
        return new JAXBElement<String>(_CategoryCategoryId_QNAME, String.class, Category.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Color", scope = Category.class)
    public JAXBElement<String> createCategoryColor(String value) {
        return new JAXBElement<String>(_CategoryColor_QNAME, String.class, Category.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Name", scope = Category.class)
    public JAXBElement<String> createCategoryName(String value) {
        return new JAXBElement<String>(_CountryName_QNAME, String.class, Category.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "VenueId", scope = Venue.class)
    public JAXBElement<String> createVenueVenueId(String value) {
        return new JAXBElement<String>(_VenueVenueId_QNAME, String.class, Venue.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Location }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Location", scope = Venue.class)
    public JAXBElement<Location> createVenueLocation(Location value) {
        return new JAXBElement<Location>(_Location_QNAME, Location.class, Venue.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Name", scope = Venue.class)
    public JAXBElement<String> createVenueName(String value) {
        return new JAXBElement<String>(_CountryName_QNAME, String.class, Venue.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "page", scope = GetArtist.class)
    public JAXBElement<PagingData> createGetArtistPage(PagingData value) {
        return new JAXBElement<PagingData>(_GetCategoriesPage_QNAME, PagingData.class, GetArtist.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "PromoVideo", scope = Artist.class)
    public JAXBElement<String> createArtistPromoVideo(String value) {
        return new JAXBElement<String>(_ArtistPromoVideo_QNAME, String.class, Artist.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Category }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Category", scope = Artist.class)
    public JAXBElement<Category> createArtistCategory(Category value) {
        return new JAXBElement<Category>(_Category_QNAME, Category.class, Artist.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link BlobData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Picture", scope = Artist.class)
    public JAXBElement<BlobData> createArtistPicture(BlobData value) {
        return new JAXBElement<BlobData>(_ArtistPicture_QNAME, BlobData.class, Artist.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Country }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Country", scope = Artist.class)
    public JAXBElement<Country> createArtistCountry(Country value) {
        return new JAXBElement<Country>(_Country_QNAME, Country.class, Artist.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "EMail", scope = Artist.class)
    public JAXBElement<String> createArtistEMail(String value) {
        return new JAXBElement<String>(_ArtistEMail_QNAME, String.class, Artist.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Name", scope = Artist.class)
    public JAXBElement<String> createArtistName(String value) {
        return new JAXBElement<String>(_CountryName_QNAME, String.class, Artist.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfLocation }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "GetLocationsResult", scope = GetLocationsResponse.class)
    public JAXBElement<ArrayOfLocation> createGetLocationsResponseGetLocationsResult(ArrayOfLocation value) {
        return new JAXBElement<ArrayOfLocation>(_GetLocationsResponseGetLocationsResult_QNAME, ArrayOfLocation.class, GetLocationsResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Artist }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Artist", scope = Performance.class)
    public JAXBElement<Artist> createPerformanceArtist(Artist value) {
        return new JAXBElement<Artist>(_Artist_QNAME, Artist.class, Performance.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Venue }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Venue", scope = Performance.class)
    public JAXBElement<Venue> createPerformanceVenue(Venue value) {
        return new JAXBElement<Venue>(_Venue_QNAME, Venue.class, Performance.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "RequestVenuePagingDataResult", scope = RequestVenuePagingDataResponse.class)
    public JAXBElement<PagingData> createRequestVenuePagingDataResponseRequestVenuePagingDataResult(PagingData value) {
        return new JAXBElement<PagingData>(_RequestVenuePagingDataResponseRequestVenuePagingDataResult_QNAME, PagingData.class, RequestVenuePagingDataResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "page", scope = GetLocations.class)
    public JAXBElement<PagingData> createGetLocationsPage(PagingData value) {
        return new JAXBElement<PagingData>(_GetCategoriesPage_QNAME, PagingData.class, GetLocations.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "page", scope = GetPerformances.class)
    public JAXBElement<PagingData> createGetPerformancesPage(PagingData value) {
        return new JAXBElement<PagingData>(_GetCategoriesPage_QNAME, PagingData.class, GetPerformances.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfPerformance }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "GetPerformancesPerDateResult", scope = GetPerformancesPerDateResponse.class)
    public JAXBElement<ArrayOfPerformance> createGetPerformancesPerDateResponseGetPerformancesPerDateResult(ArrayOfPerformance value) {
        return new JAXBElement<ArrayOfPerformance>(_GetPerformancesPerDateResponseGetPerformancesPerDateResult_QNAME, ArrayOfPerformance.class, GetPerformancesPerDateResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfArtist }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "GetArtistResult", scope = GetArtistResponse.class)
    public JAXBElement<ArrayOfArtist> createGetArtistResponseGetArtistResult(ArrayOfArtist value) {
        return new JAXBElement<ArrayOfArtist>(_GetArtistResponseGetArtistResult_QNAME, ArrayOfArtist.class, GetArtistResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link PagingData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "RequestCategoryPagingDataResult", scope = RequestCategoryPagingDataResponse.class)
    public JAXBElement<PagingData> createRequestCategoryPagingDataResponseRequestCategoryPagingDataResult(PagingData value) {
        return new JAXBElement<PagingData>(_RequestCategoryPagingDataResponseRequestCategoryPagingDataResult_QNAME, PagingData.class, RequestCategoryPagingDataResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfCategory }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "GetCategoriesResult", scope = GetCategoriesResponse.class)
    public JAXBElement<ArrayOfCategory> createGetCategoriesResponseGetCategoriesResult(ArrayOfCategory value) {
        return new JAXBElement<ArrayOfCategory>(_GetCategoriesResponseGetCategoriesResult_QNAME, ArrayOfCategory.class, GetCategoriesResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Path", scope = BlobData.class)
    public JAXBElement<String> createBlobDataPath(String value) {
        return new JAXBElement<String>(_BlobDataPath_QNAME, String.class, BlobData.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link byte[]}{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "DataStream", scope = BlobData.class)
    public JAXBElement<byte[]> createBlobDataDataStream(byte[] value) {
        return new JAXBElement<byte[]>(_BlobDataDataStream_QNAME, byte[].class, BlobData.class, ((byte[]) value));
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Name", scope = BlobData.class)
    public JAXBElement<String> createBlobDataName(String value) {
        return new JAXBElement<String>(_CountryName_QNAME, String.class, BlobData.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfVenue }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://tempuri.org/", name = "GetVenuesResult", scope = GetVenuesResponse.class)
    public JAXBElement<ArrayOfVenue> createGetVenuesResponseGetVenuesResult(ArrayOfVenue value) {
        return new JAXBElement<ArrayOfVenue>(_GetVenuesResponseGetVenuesResult_QNAME, ArrayOfVenue.class, GetVenuesResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", name = "Name", scope = Location.class)
    public JAXBElement<String> createLocationName(String value) {
        return new JAXBElement<String>(_CountryName_QNAME, String.class, Location.class, value);
    }

}
