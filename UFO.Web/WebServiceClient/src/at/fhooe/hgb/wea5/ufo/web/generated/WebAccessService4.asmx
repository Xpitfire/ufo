<?xml version="1.0" encoding="utf-8"?>
<wsdl:definitions xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:tns="http://ufo.at/" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:s1="http://microsoft.com/wsdl/types/" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" targetNamespace="http://ufo.at/" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="http://ufo.at/">
      <s:import namespace="http://microsoft.com/wsdl/types/" />
      <s:element name="GetArtist">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="page" type="tns:PagingData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="PagingData">
        <s:complexContent mixed="false">
          <s:extension base="tns:DomainObject">
            <s:sequence>
              <s:element minOccurs="1" maxOccurs="1" name="Offset" type="s:long" />
              <s:element minOccurs="1" maxOccurs="1" name="Request" type="s:long" />
              <s:element minOccurs="1" maxOccurs="1" name="Size" type="s:long" />
              <s:element minOccurs="1" maxOccurs="1" name="Remaining" type="s:long" />
            </s:sequence>
          </s:extension>
        </s:complexContent>
      </s:complexType>
      <s:complexType name="DomainObject" />
      <s:complexType name="BlobData">
        <s:complexContent mixed="false">
          <s:extension base="tns:DomainObject">
            <s:sequence>
              <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
              <s:element minOccurs="0" maxOccurs="1" name="Path" type="s:string" />
              <s:element minOccurs="0" maxOccurs="1" name="DataStream" type="s:base64Binary" />
            </s:sequence>
          </s:extension>
        </s:complexContent>
      </s:complexType>
      <s:complexType name="Country">
        <s:complexContent mixed="false">
          <s:extension base="tns:DomainObject">
            <s:sequence>
              <s:element minOccurs="0" maxOccurs="1" name="Code" type="s:string" />
              <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
            </s:sequence>
          </s:extension>
        </s:complexContent>
      </s:complexType>
      <s:complexType name="Category">
        <s:complexContent mixed="false">
          <s:extension base="tns:DomainObject">
            <s:sequence>
              <s:element minOccurs="0" maxOccurs="1" name="CategoryId" type="s:string" />
              <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
              <s:element minOccurs="0" maxOccurs="1" name="Color" type="s:string" />
            </s:sequence>
          </s:extension>
        </s:complexContent>
      </s:complexType>
      <s:complexType name="Artist">
        <s:complexContent mixed="false">
          <s:extension base="tns:DomainObject">
            <s:sequence>
              <s:element minOccurs="1" maxOccurs="1" name="ArtistId" type="s:int" />
              <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
              <s:element minOccurs="0" maxOccurs="1" name="EMail" type="s:string" />
              <s:element minOccurs="0" maxOccurs="1" name="Category" type="tns:Category" />
              <s:element minOccurs="0" maxOccurs="1" name="Country" type="tns:Country" />
              <s:element minOccurs="0" maxOccurs="1" name="Picture" type="tns:BlobData" />
              <s:element minOccurs="0" maxOccurs="1" name="PromoVideo" type="s:string" />
            </s:sequence>
          </s:extension>
        </s:complexContent>
      </s:complexType>
      <s:element name="GetArtistResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetArtistResult" type="tns:ArrayOfArtist" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfArtist">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Artist" nillable="true" type="tns:Artist" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetCategories">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="page" type="tns:PagingData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetCategoriesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetCategoriesResult" type="tns:ArrayOfCategory" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfCategory">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Category" nillable="true" type="tns:Category" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetCountries">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="page" type="tns:PagingData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetCountriesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetCountriesResult" type="tns:ArrayOfCountry" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfCountry">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Country" nillable="true" type="tns:Country" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetLocations">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="page" type="tns:PagingData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetLocationsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetLocationsResult" type="tns:ArrayOfLocation" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfLocation">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Location" nillable="true" type="tns:Location" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="Location">
        <s:complexContent mixed="false">
          <s:extension base="tns:DomainObject">
            <s:sequence>
              <s:element minOccurs="1" maxOccurs="1" name="LocationId" type="s:int" />
              <s:element minOccurs="1" maxOccurs="1" name="Longitude" type="s:decimal" />
              <s:element minOccurs="1" maxOccurs="1" name="Latitude" type="s:decimal" />
              <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
            </s:sequence>
          </s:extension>
        </s:complexContent>
      </s:complexType>
      <s:element name="GetVenues">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="page" type="tns:PagingData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetVenuesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetVenuesResult" type="tns:ArrayOfVenue" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfVenue">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Venue" nillable="true" type="tns:Venue" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="Venue">
        <s:complexContent mixed="false">
          <s:extension base="tns:DomainObject">
            <s:sequence>
              <s:element minOccurs="0" maxOccurs="1" name="VenueId" type="s:string" />
              <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
              <s:element minOccurs="0" maxOccurs="1" name="Location" type="tns:Location" />
            </s:sequence>
          </s:extension>
        </s:complexContent>
      </s:complexType>
      <s:element name="GetPerformances">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="page" type="tns:PagingData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetPerformancesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetPerformancesResult" type="tns:ArrayOfPerformance" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfPerformance">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Performance" nillable="true" type="tns:Performance" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="Performance">
        <s:complexContent mixed="false">
          <s:extension base="tns:DomainObject">
            <s:sequence>
              <s:element minOccurs="1" maxOccurs="1" name="DateTime" type="s:dateTime" />
              <s:element minOccurs="0" maxOccurs="1" name="Artist" type="tns:Artist" />
              <s:element minOccurs="0" maxOccurs="1" name="Venue" type="tns:Venue" />
            </s:sequence>
          </s:extension>
        </s:complexContent>
      </s:complexType>
      <s:element name="GetPerformancesPerDate">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="date" type="s:dateTime" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetPerformancesPerDateResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetPerformancesPerDateResult" type="tns:ArrayOfPerformance" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RequestArtistPagingData">
        <s:complexType />
      </s:element>
      <s:element name="RequestArtistPagingDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RequestArtistPagingDataResult" type="tns:PagingData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RequestCategoryPagingData">
        <s:complexType />
      </s:element>
      <s:element name="RequestCategoryPagingDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RequestCategoryPagingDataResult" type="tns:PagingData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RequestCountryPagingData">
        <s:complexType />
      </s:element>
      <s:element name="RequestCountryPagingDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RequestCountryPagingDataResult" type="tns:PagingData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RequestLocationPagingData">
        <s:complexType />
      </s:element>
      <s:element name="RequestLocationPagingDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RequestLocationPagingDataResult" type="tns:PagingData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RequestPerformancePagingData">
        <s:complexType />
      </s:element>
      <s:element name="RequestPerformancePagingDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RequestPerformancePagingDataResult" type="tns:PagingData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RequestVenuePagingData">
        <s:complexType />
      </s:element>
      <s:element name="RequestVenuePagingDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RequestVenuePagingDataResult" type="tns:PagingData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="IsUserAuthenticated">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="token" type="tns:SessionToken" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="SessionToken">
        <s:complexContent mixed="false">
          <s:extension base="tns:DomainObject">
            <s:sequence>
              <s:element minOccurs="0" maxOccurs="1" name="SessionId" type="tns:ArrayOfChar" />
              <s:element minOccurs="0" maxOccurs="1" name="User" type="tns:User" />
            </s:sequence>
          </s:extension>
        </s:complexContent>
      </s:complexType>
      <s:complexType name="ArrayOfChar">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="char" type="s1:char" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="User">
        <s:complexContent mixed="false">
          <s:extension base="tns:DomainObject">
            <s:sequence>
              <s:element minOccurs="1" maxOccurs="1" name="UserId" type="s:int" />
              <s:element minOccurs="0" maxOccurs="1" name="FirstName" type="s:string" />
              <s:element minOccurs="0" maxOccurs="1" name="LastName" type="s:string" />
              <s:element minOccurs="0" maxOccurs="1" name="EMail" type="s:string" />
              <s:element minOccurs="0" maxOccurs="1" name="Password" type="s:string" />
              <s:element minOccurs="1" maxOccurs="1" name="IsAdmin" type="s:boolean" />
              <s:element minOccurs="1" maxOccurs="1" name="IsArtist" type="s:boolean" />
              <s:element minOccurs="0" maxOccurs="1" name="Artist" type="tns:Artist" />
            </s:sequence>
          </s:extension>
        </s:complexContent>
      </s:complexType>
      <s:element name="IsUserAuthenticatedResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="IsUserAuthenticatedResult" type="s:boolean" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoginAdmin">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="token" type="tns:SessionToken" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoginAdminResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="LoginAdminResult" type="s:boolean" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LogoutAdmin">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="token" type="tns:SessionToken" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LogoutAdminResponse">
        <s:complexType />
      </s:element>
      <s:element name="RequestSessionToken">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="user" type="tns:User" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RequestSessionTokenResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RequestSessionTokenResult" type="tns:SessionToken" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ModifyPerformance">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="token" type="tns:SessionToken" />
            <s:element minOccurs="0" maxOccurs="1" name="performance" type="tns:Performance" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ModifyPerformanceResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="ModifyPerformanceResult" type="s:boolean" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
    <s:schema elementFormDefault="qualified" targetNamespace="http://microsoft.com/wsdl/types/">
      <s:simpleType name="char">
        <s:restriction base="s:unsignedShort" />
      </s:simpleType>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="GetArtistSoapIn">
    <wsdl:part name="parameters" element="tns:GetArtist" />
  </wsdl:message>
  <wsdl:message name="GetArtistSoapOut">
    <wsdl:part name="parameters" element="tns:GetArtistResponse" />
  </wsdl:message>
  <wsdl:message name="GetCategoriesSoapIn">
    <wsdl:part name="parameters" element="tns:GetCategories" />
  </wsdl:message>
  <wsdl:message name="GetCategoriesSoapOut">
    <wsdl:part name="parameters" element="tns:GetCategoriesResponse" />
  </wsdl:message>
  <wsdl:message name="GetCountriesSoapIn">
    <wsdl:part name="parameters" element="tns:GetCountries" />
  </wsdl:message>
  <wsdl:message name="GetCountriesSoapOut">
    <wsdl:part name="parameters" element="tns:GetCountriesResponse" />
  </wsdl:message>
  <wsdl:message name="GetLocationsSoapIn">
    <wsdl:part name="parameters" element="tns:GetLocations" />
  </wsdl:message>
  <wsdl:message name="GetLocationsSoapOut">
    <wsdl:part name="parameters" element="tns:GetLocationsResponse" />
  </wsdl:message>
  <wsdl:message name="GetVenuesSoapIn">
    <wsdl:part name="parameters" element="tns:GetVenues" />
  </wsdl:message>
  <wsdl:message name="GetVenuesSoapOut">
    <wsdl:part name="parameters" element="tns:GetVenuesResponse" />
  </wsdl:message>
  <wsdl:message name="GetPerformancesSoapIn">
    <wsdl:part name="parameters" element="tns:GetPerformances" />
  </wsdl:message>
  <wsdl:message name="GetPerformancesSoapOut">
    <wsdl:part name="parameters" element="tns:GetPerformancesResponse" />
  </wsdl:message>
  <wsdl:message name="GetPerformancesPerDateSoapIn">
    <wsdl:part name="parameters" element="tns:GetPerformancesPerDate" />
  </wsdl:message>
  <wsdl:message name="GetPerformancesPerDateSoapOut">
    <wsdl:part name="parameters" element="tns:GetPerformancesPerDateResponse" />
  </wsdl:message>
  <wsdl:message name="RequestArtistPagingDataSoapIn">
    <wsdl:part name="parameters" element="tns:RequestArtistPagingData" />
  </wsdl:message>
  <wsdl:message name="RequestArtistPagingDataSoapOut">
    <wsdl:part name="parameters" element="tns:RequestArtistPagingDataResponse" />
  </wsdl:message>
  <wsdl:message name="RequestCategoryPagingDataSoapIn">
    <wsdl:part name="parameters" element="tns:RequestCategoryPagingData" />
  </wsdl:message>
  <wsdl:message name="RequestCategoryPagingDataSoapOut">
    <wsdl:part name="parameters" element="tns:RequestCategoryPagingDataResponse" />
  </wsdl:message>
  <wsdl:message name="RequestCountryPagingDataSoapIn">
    <wsdl:part name="parameters" element="tns:RequestCountryPagingData" />
  </wsdl:message>
  <wsdl:message name="RequestCountryPagingDataSoapOut">
    <wsdl:part name="parameters" element="tns:RequestCountryPagingDataResponse" />
  </wsdl:message>
  <wsdl:message name="RequestLocationPagingDataSoapIn">
    <wsdl:part name="parameters" element="tns:RequestLocationPagingData" />
  </wsdl:message>
  <wsdl:message name="RequestLocationPagingDataSoapOut">
    <wsdl:part name="parameters" element="tns:RequestLocationPagingDataResponse" />
  </wsdl:message>
  <wsdl:message name="RequestPerformancePagingDataSoapIn">
    <wsdl:part name="parameters" element="tns:RequestPerformancePagingData" />
  </wsdl:message>
  <wsdl:message name="RequestPerformancePagingDataSoapOut">
    <wsdl:part name="parameters" element="tns:RequestPerformancePagingDataResponse" />
  </wsdl:message>
  <wsdl:message name="RequestVenuePagingDataSoapIn">
    <wsdl:part name="parameters" element="tns:RequestVenuePagingData" />
  </wsdl:message>
  <wsdl:message name="RequestVenuePagingDataSoapOut">
    <wsdl:part name="parameters" element="tns:RequestVenuePagingDataResponse" />
  </wsdl:message>
  <wsdl:message name="IsUserAuthenticatedSoapIn">
    <wsdl:part name="parameters" element="tns:IsUserAuthenticated" />
  </wsdl:message>
  <wsdl:message name="IsUserAuthenticatedSoapOut">
    <wsdl:part name="parameters" element="tns:IsUserAuthenticatedResponse" />
  </wsdl:message>
  <wsdl:message name="LoginAdminSoapIn">
    <wsdl:part name="parameters" element="tns:LoginAdmin" />
  </wsdl:message>
  <wsdl:message name="LoginAdminSoapOut">
    <wsdl:part name="parameters" element="tns:LoginAdminResponse" />
  </wsdl:message>
  <wsdl:message name="LogoutAdminSoapIn">
    <wsdl:part name="parameters" element="tns:LogoutAdmin" />
  </wsdl:message>
  <wsdl:message name="LogoutAdminSoapOut">
    <wsdl:part name="parameters" element="tns:LogoutAdminResponse" />
  </wsdl:message>
  <wsdl:message name="RequestSessionTokenSoapIn">
    <wsdl:part name="parameters" element="tns:RequestSessionToken" />
  </wsdl:message>
  <wsdl:message name="RequestSessionTokenSoapOut">
    <wsdl:part name="parameters" element="tns:RequestSessionTokenResponse" />
  </wsdl:message>
  <wsdl:message name="ModifyPerformanceSoapIn">
    <wsdl:part name="parameters" element="tns:ModifyPerformance" />
  </wsdl:message>
  <wsdl:message name="ModifyPerformanceSoapOut">
    <wsdl:part name="parameters" element="tns:ModifyPerformanceResponse" />
  </wsdl:message>
  <wsdl:portType name="WebAccessServiceSoap">
    <wsdl:operation name="GetArtist">
      <wsdl:input message="tns:GetArtistSoapIn" />
      <wsdl:output message="tns:GetArtistSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetCategories">
      <wsdl:input message="tns:GetCategoriesSoapIn" />
      <wsdl:output message="tns:GetCategoriesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetCountries">
      <wsdl:input message="tns:GetCountriesSoapIn" />
      <wsdl:output message="tns:GetCountriesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetLocations">
      <wsdl:input message="tns:GetLocationsSoapIn" />
      <wsdl:output message="tns:GetLocationsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetVenues">
      <wsdl:input message="tns:GetVenuesSoapIn" />
      <wsdl:output message="tns:GetVenuesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetPerformances">
      <wsdl:input message="tns:GetPerformancesSoapIn" />
      <wsdl:output message="tns:GetPerformancesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetPerformancesPerDate">
      <wsdl:input message="tns:GetPerformancesPerDateSoapIn" />
      <wsdl:output message="tns:GetPerformancesPerDateSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RequestArtistPagingData">
      <wsdl:input message="tns:RequestArtistPagingDataSoapIn" />
      <wsdl:output message="tns:RequestArtistPagingDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RequestCategoryPagingData">
      <wsdl:input message="tns:RequestCategoryPagingDataSoapIn" />
      <wsdl:output message="tns:RequestCategoryPagingDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RequestCountryPagingData">
      <wsdl:input message="tns:RequestCountryPagingDataSoapIn" />
      <wsdl:output message="tns:RequestCountryPagingDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RequestLocationPagingData">
      <wsdl:input message="tns:RequestLocationPagingDataSoapIn" />
      <wsdl:output message="tns:RequestLocationPagingDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RequestPerformancePagingData">
      <wsdl:input message="tns:RequestPerformancePagingDataSoapIn" />
      <wsdl:output message="tns:RequestPerformancePagingDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RequestVenuePagingData">
      <wsdl:input message="tns:RequestVenuePagingDataSoapIn" />
      <wsdl:output message="tns:RequestVenuePagingDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="IsUserAuthenticated">
      <wsdl:input message="tns:IsUserAuthenticatedSoapIn" />
      <wsdl:output message="tns:IsUserAuthenticatedSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LoginAdmin">
      <wsdl:input message="tns:LoginAdminSoapIn" />
      <wsdl:output message="tns:LoginAdminSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LogoutAdmin">
      <wsdl:input message="tns:LogoutAdminSoapIn" />
      <wsdl:output message="tns:LogoutAdminSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="RequestSessionToken">
      <wsdl:input message="tns:RequestSessionTokenSoapIn" />
      <wsdl:output message="tns:RequestSessionTokenSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="ModifyPerformance">
      <wsdl:input message="tns:ModifyPerformanceSoapIn" />
      <wsdl:output message="tns:ModifyPerformanceSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="WebAccessServiceSoap" type="tns:WebAccessServiceSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="GetArtist">
      <soap:operation soapAction="http://ufo.at/GetArtist" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCategories">
      <soap:operation soapAction="http://ufo.at/GetCategories" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCountries">
      <soap:operation soapAction="http://ufo.at/GetCountries" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetLocations">
      <soap:operation soapAction="http://ufo.at/GetLocations" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetVenues">
      <soap:operation soapAction="http://ufo.at/GetVenues" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPerformances">
      <soap:operation soapAction="http://ufo.at/GetPerformances" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPerformancesPerDate">
      <soap:operation soapAction="http://ufo.at/GetPerformancesPerDate" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestArtistPagingData">
      <soap:operation soapAction="http://ufo.at/RequestArtistPagingData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestCategoryPagingData">
      <soap:operation soapAction="http://ufo.at/RequestCategoryPagingData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestCountryPagingData">
      <soap:operation soapAction="http://ufo.at/RequestCountryPagingData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestLocationPagingData">
      <soap:operation soapAction="http://ufo.at/RequestLocationPagingData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestPerformancePagingData">
      <soap:operation soapAction="http://ufo.at/RequestPerformancePagingData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestVenuePagingData">
      <soap:operation soapAction="http://ufo.at/RequestVenuePagingData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="IsUserAuthenticated">
      <soap:operation soapAction="http://ufo.at/IsUserAuthenticated" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoginAdmin">
      <soap:operation soapAction="http://ufo.at/LoginAdmin" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LogoutAdmin">
      <soap:operation soapAction="http://ufo.at/LogoutAdmin" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestSessionToken">
      <soap:operation soapAction="http://ufo.at/RequestSessionToken" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ModifyPerformance">
      <soap:operation soapAction="http://ufo.at/ModifyPerformance" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="WebAccessServiceSoap12" type="tns:WebAccessServiceSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="GetArtist">
      <soap12:operation soapAction="http://ufo.at/GetArtist" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCategories">
      <soap12:operation soapAction="http://ufo.at/GetCategories" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCountries">
      <soap12:operation soapAction="http://ufo.at/GetCountries" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetLocations">
      <soap12:operation soapAction="http://ufo.at/GetLocations" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetVenues">
      <soap12:operation soapAction="http://ufo.at/GetVenues" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPerformances">
      <soap12:operation soapAction="http://ufo.at/GetPerformances" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPerformancesPerDate">
      <soap12:operation soapAction="http://ufo.at/GetPerformancesPerDate" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestArtistPagingData">
      <soap12:operation soapAction="http://ufo.at/RequestArtistPagingData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestCategoryPagingData">
      <soap12:operation soapAction="http://ufo.at/RequestCategoryPagingData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestCountryPagingData">
      <soap12:operation soapAction="http://ufo.at/RequestCountryPagingData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestLocationPagingData">
      <soap12:operation soapAction="http://ufo.at/RequestLocationPagingData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestPerformancePagingData">
      <soap12:operation soapAction="http://ufo.at/RequestPerformancePagingData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestVenuePagingData">
      <soap12:operation soapAction="http://ufo.at/RequestVenuePagingData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="IsUserAuthenticated">
      <soap12:operation soapAction="http://ufo.at/IsUserAuthenticated" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoginAdmin">
      <soap12:operation soapAction="http://ufo.at/LoginAdmin" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LogoutAdmin">
      <soap12:operation soapAction="http://ufo.at/LogoutAdmin" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="RequestSessionToken">
      <soap12:operation soapAction="http://ufo.at/RequestSessionToken" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ModifyPerformance">
      <soap12:operation soapAction="http://ufo.at/ModifyPerformance" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="WebAccessService">
    <wsdl:port name="WebAccessServiceSoap" binding="tns:WebAccessServiceSoap">
      <soap:address location="http://localhost:52500/WebAccessService.asmx" />
    </wsdl:port>
    <wsdl:port name="WebAccessServiceSoap12" binding="tns:WebAccessServiceSoap12">
      <soap12:address location="http://localhost:52500/WebAccessService.asmx" />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>