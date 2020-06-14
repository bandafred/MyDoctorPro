import * as React from "react";
import {Row, Col} from "antd";
import {useState} from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import {IResult} from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {AntihypertensiveTherapyResponse} from "../../../../apiClient/apiClient";
import InputInt from "../../FormsComponets/InputInt/InputInt";
import SexSelect from "../../FormsComponets/SexSelect/SexSelect";
import ResultAntiHypertensionTherapy
    from "../../FormsComponets/ResultAntiHypertensionTherapy/ResultAntiHypertensionTherapy";
import {Disease} from "./Disease";
import {AntihypertensiveTherapyResult} from "./AntihypertensiveTherapyAction";

const AntihypertensiveTherapy = () => {
    let def: IResult<AntihypertensiveTherapyResponse> = {
        error: undefined,
        result: undefined,
    };

    let diseasesVal: number[] = [];

    let ageDefault = 50;
    let systolicBloodPressureDefault = 150;
    let diastolicBloodPressureDefault = 90;
    let pulseDefault = 90;

    const [age, serAge] = useState(ageDefault);
    const [isMen, setIsMen] = useState(false);
    const [systolicBloodPressure, setSystolicBloodPressure] = useState(
        systolicBloodPressureDefault
    );
    const [diastolicBloodPressure, setDiastolicBloodPressure] = useState(
        diastolicBloodPressureDefault
    );
    const [pulse, setPulse] = useState(pulseDefault);
    const [diseases, setDiseases] = useState(diseasesVal);

    const [result, setResult] = useState(def);
    const [isLoad, setIsLoad] = useState(false);

    const calcing = async () => {
        setIsLoad(true);
        setResult(
            await AntihypertensiveTherapyResult(
                age,
                isMen,
                systolicBloodPressure,
                diastolicBloodPressure,
                pulse,
                diseases
            )
        );
        setIsLoad(false);
    };

    return (
        <Row style={{marginBottom: 100}}>
            <Col span={24}>
                <TitleCalculatorArray
                    name={"Подбор гипотензивной терапии"}
                    description={[]}
                />
            </Col>

            <Col xl={4} style={{marginTop: 10}}>
                <SexSelect setAction={setIsMen}/>
            </Col>

            <Col xl={4} style={{marginTop: 10}}>
                <InputInt
                    default={ageDefault}
                    max={150}
                    min={1}
                    setAction={serAge}
                    preName={"Возраст"}
                />
            </Col>

            <Col xl={24} style={{marginTop: 10}}>
                <InputInt
                    default={systolicBloodPressureDefault}
                    max={350}
                    min={1}
                    setAction={setSystolicBloodPressure}
                    preName={
                        "Максимальные цифры систолического (верхнего) артериального давления"
                    }
                    postName={"мм.рт.ст."}
                />
            </Col>

            <Col xl={24} style={{marginTop: 10}}>
                <InputInt
                    default={diastolicBloodPressureDefault}
                    max={350}
                    min={1}
                    setAction={setDiastolicBloodPressure}
                    preName={
                        "Максимальные цифры диастолического (нижнего) артериального давления"
                    }
                    postName={"мм.рт.ст."}
                />
            </Col>

            <Col xl={24} style={{marginTop: 10}}>
                <InputInt
                    default={pulseDefault}
                    max={350}
                    min={1}
                    setAction={setPulse}
                    preName={"Средние цифры пульса"}
                    postName={"уд/мин."}
                />
            </Col>

            <Col xl={24} style={{marginTop: 10}}>
                <h3 style={{textAlign: "center"}}>Сопутствующие заболевания:</h3>
                <Disease setDiseases={setDiseases}/>
            </Col>

            <Col xl={24}>
                <ButtonResult isLoad={isLoad} calcing={calcing}/>
            </Col>

            <Col xl={24}>
                <ResultAntiHypertensionTherapy
                    result={result.result}
                    error={result.error}
                />
            </Col>
        </Row>
    );
};
export default AntihypertensiveTherapy;
