import * as React from "react";
import { Route } from "react-router";
import Layout from "./components/Layout";
import Home from "./components/Home";
import IndexSolovievaStoreIndex from "./components/Forms/IdealBodyWeight/IndexSolovieva/IndexSolovieva";
import LorentzFormulaIndex from "./components/Forms/IdealBodyWeight/LorentzFormula/LorentzFormula";
import IndexBrokaIndex from "./components/Forms/IdealBodyWeight/IndexBroka/IndexBroka";
import IndexBrokaBruksha from "./components/Forms/IdealBodyWeight/IndexBrokaBruksha/IndexBrokaBruksha";
import CuperFormula from "./components/Forms/IdealBodyWeight/CuperFormula/CuperFormula";
import IndexBorngardt from "./components/Forms/IdealBodyWeight/IndexBorngardt/IndexBorngardt";
import DevinFormula from "./components/Forms/IdealBodyWeight/DevinFormula/DevinFormula";
import EgorovaTable from "./components/Forms/IdealBodyWeight/EgorovaTable/EgorovaTable";
import MillerFormula from "./components/Forms/IdealBodyWeight/MillerFormula/MillerFormula";
import KreffFormula from "./components/Forms/IdealBodyWeight/KreffFormula/KreffFormula";
import NaglerFormula from "./components/Forms/IdealBodyWeight/NaglerFormula/NaglerFormula";
import MochammedFormula from "./components/Forms/IdealBodyWeight/MochammedFormula/MochammedFormula";
import RobinsonFormula from "./components/Forms/IdealBodyWeight/RobinsonFormula/RobinsonFormula";
import MonnerotFormula from "./components/Forms/IdealBodyWeight/MonnerotFormula/MonnerotFormula";
import HamviFormula from "./components/Forms/IdealBodyWeight/HamviFormula/HamviFormula";
import General from "./components/Forms/IdealBodyWeight/General/General";
import BodyMassIndex from "./components/Forms/MedicalCalculate/BodyMassIndex/BodyMassIndex";
import Score from "./components/Forms/MedicalCalculate/SCORE/Score";
import Timi from "./components/Forms/MedicalCalculate/TIMI/Timi";
import CHA2DS2VASc from "./components/Forms/MedicalCalculate/CHA2DS2VASc/CHA2DS2VASc";
import HASBLED from "./components/Forms/MedicalCalculate/HAS-BLED/HASBLED";
import KIN from "./components/Forms/MedicalCalculate/KIN/KIN";
import GRACE from "./components/Forms/MedicalCalculate/GRACE/GRACE";
import GlomerularFiltrationRate from "./components/Forms/MedicalCalculate/GlomerularFiltrationRate/GlomerularFiltrationRate";
import IndexSmoke from "./components/Forms/MedicalCalculate/IndexSmoke/IndexSmoke";
import CorrectedQTCalculation from "./components/Forms/MedicalCalculate/CorrectedQTCalculation/CorrectedQTCalculation";
import InfusionRate from "./components/Forms/MedicalCalculate/InfusionRate/InfusionRate";
import PotassiumDeficiency from "./components/Forms/MedicalCalculate/PotassiumDeficiency/PotassiumDeficiency";
import SubstanceinSolution from "./components/Forms/MedicalCalculate/SubstanceinSolution/SubstanceinSolution";
import Glasgo from "./components/Forms/MedicalCalculate/Glasgo/Glasgo";
import Order302N from "./components/Forms/Dictionaries/Order302N/Order302N";
import GeneralMedicalContraindication from "./components/Forms/Dictionaries/GeneralMedicalContraindication/GeneralMedicalContraindication";
import AntihypertensiveTherapy from "./components/Forms/MedicalCalculate/AntihypertensiveTherapy/AntihypertensiveTherapy";
import Mkb10 from "./components/Forms/Dictionaries/Mkb10/Mkb10";
import Order417N from "./components/Forms/Dictionaries/Order417N/Order417N";
import {LoginForm} from "./components/Forms/User/LoginForm/LoginForm";
import {RegistrationForm} from "./components/Forms/User/RegistrationForm/RegistrationForm";
import {SettingsMenu} from "./components/Forms/User/SettingsMenu/SettingsMenu";
import {PasswordRecoveryForm} from "./components/Forms/User/PasswordRecoveryForm/PasswordRecoveryForm";
import {ArterialPressureIndex} from "./components/Forms/ArterialPressure/ArterialPressureIndex";
import {AddRecord} from "./components/Forms/ArterialPressure/AddRecord";
import {RecordsList} from "./components/Forms/ArterialPressure/RecordsList";
import "./custom.css";
import {EditUserInfo} from "./components/Forms/User/EditUserInfo/EditUserInfo";

export default () => (
  <Layout>
    <Route exact path="/" component={Home} />
    <Route path="/IndexSolovieva" component={IndexSolovievaStoreIndex} />
    <Route path="/LorentzFormula" component={LorentzFormulaIndex} />
    <Route path="/IndexBroka" component={IndexBrokaIndex} />
    <Route path="/IndexBrokaBruksha" component={IndexBrokaBruksha} />
    <Route path="/CuperFormula" component={CuperFormula} />
    <Route path="/IndexBorngardt" component={IndexBorngardt} />
    <Route path="/DevinFormula" component={DevinFormula} />
    <Route path="/EgorovaTable" component={EgorovaTable} />
    <Route path="/MillerFormula" component={MillerFormula} />
    <Route path="/KreffFormula" component={KreffFormula} />
    <Route path="/NaglerFormula" component={NaglerFormula} />
    <Route path="/MochammedFormula" component={MochammedFormula} />
    <Route path="/RobinsonFormula" component={RobinsonFormula} />
    <Route path="/MonnerotFormula" component={MonnerotFormula} />
    <Route path="/HamviFormula" component={HamviFormula} />
    <Route path="/HamviFormula" component={HamviFormula} />
    <Route path="/General" component={General} />

    <Route path="/IMT" component={BodyMassIndex} />
    <Route path="/Score" component={Score} />
    <Route path="/Timi" component={Timi} />
    <Route path="/CHA2DS2VASc" component={CHA2DS2VASc} />
    <Route path="/HASBLED" component={HASBLED} />
    <Route path="/KIN" component={KIN} />
    <Route path="/GRACE" component={GRACE} />
    <Route path="/GlomerularFiltrationRate" component={GlomerularFiltrationRate} />
    <Route path="/IndexSmoke" component={IndexSmoke} />
    <Route path="/CorrectedQTCalculation" component={CorrectedQTCalculation} />
    <Route path="/InfusionRate" component={InfusionRate} />
    <Route path="/PotassiumDeficiency" component={PotassiumDeficiency} />
    <Route path="/SubstanceinSolution" component={SubstanceinSolution} />
    <Route path="/Glasgo" component={Glasgo} />
    <Route path="/AntihypertensiveTherapy" component={AntihypertensiveTherapy} />

    <Route path="/Order302N" component={Order302N} />
    <Route path="/GeneralMedicalContraindication" component={GeneralMedicalContraindication} />
    <Route path="/Mkb10" component={Mkb10} />
    <Route path="/Order417N" component={Order417N} />
    
    <Route path="/Login" component={LoginForm} />
    <Route path="/EditUserInfo" component={EditUserInfo} />
    <Route path="/Registration" component={RegistrationForm} />
    <Route path="/SettingsMenu" component={SettingsMenu} />
    <Route path="/PasswordRecovery/:token?" component={PasswordRecoveryForm} />
        
    <Route path="/ArterialPressure" component={ArterialPressureIndex} />
    <Route path="/AddNote" component={AddRecord} />
    <Route path="/ViewRecords" component={RecordsList} />
  </Layout>
);


