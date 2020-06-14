import * as React from "react";
import {Row, Col} from "antd";
import {useState} from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import {IResult} from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {
    InfusionRateResponse,
} from "../../../../apiClient/apiClient";
import InputInt from "../../FormsComponets/InputInt/InputInt";
import {InfusionRateResult} from "./InfusionRateAction";

const InfusionRate = () => {
    let def: IResult<InfusionRateResponse> = {
        error: undefined,
        result: undefined,
    };

    let bodyMassDefault = 70;
    let amountDrugDefault = 1;
    let volumeSolutionDefault = 1;
    let doseDefault = 1;

    const [bodyMass, serBodyMass] = useState(bodyMassDefault);
    const [amountDrug, setAmountDrug] = useState(amountDrugDefault);
    const [volumeSolution, setVolumeSolution] = useState(volumeSolutionDefault);
    const [dose, setDose] = useState(doseDefault);

    const [result, setResult] = useState(def);
    const [isLoad, setIsLoad] = useState(false);

    const calcing = async () => {
        setIsLoad(true);
        setResult(await InfusionRateResult(bodyMass, amountDrug, volumeSolution, dose));
        setIsLoad(false);
    };

    return (
        <Row style={{marginBottom: 100}}>
            <Col span={24}>
                <TitleCalculatorArray
                    name={"Расчет скорости инфузии препарата через линеомат (скорость титрования)"}
                    description={[
                        "Этот калькулятор позволяет рассчитать скорость инфузии препарата через линеомат (скорость титрования в мл/час) при известном количестве препарата в миллиграммах в известном объеме раствора. Также необходимо указать вес пациента и дозировку, определяемую в мкг*кг/мин.",
                        "Скорость инфузии = масса тела пациента (кг) * доза препарата (мкг/кг*мин) / (количество препарата в инфузионном растворе (мг) * (1 000/общий объем инфузионного раствора))*60.",
                    ]}
                />
            </Col>

            <Col xl={6} style={{marginTop: 10}}>
                <InputInt
                    default={bodyMassDefault}
                    max={999}
                    min={1}
                    setAction={serBodyMass}
                    preName={"Масса тела"}
                    postName={"кг."}
                />
            </Col>

            <Col xl={6} style={{marginTop: 10}}>
                <InputInt
                    default={amountDrugDefault}
                    max={999}
                    min={1}
                    setAction={setAmountDrug}
                    preName={"Количество препарата"}
                    postName={"мг."}
                />
            </Col>

            <Col xl={6} style={{marginTop: 10}}>
                <InputInt
                    default={volumeSolutionDefault}
                    max={999}
                    min={1}
                    setAction={setVolumeSolution}
                    preName={"Объем раствора"}
                    postName={"мл."}
                />
            </Col>

            <Col xl={6} style={{marginTop: 10}}>
                <InputInt
                    default={doseDefault}
                    max={999}
                    min={1}
                    setAction={setDose}
                    preName={"Доза препарата"}
                    postName={"мкг*кг/мин."}
                />
            </Col>

            <Col xl={24}>
                <ButtonResult isLoad={isLoad} calcing={calcing}/>
            </Col>

            <Col xl={24}>
                <ResultMedCalcilate
                    result={result.result?.result}
                    error={result.error}
                />
            </Col>
        </Row>
    );
};
export default InfusionRate;
