import {
    GraceScaleResponse,
    GraceScaleClient,
} from "../../../../apiClient/apiClient";
import {IResult, ISelectNameValue} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";

export async function GRACEResult(
    age: number,
    heartRate: number,
    systolicBloodPressure: number,
    creatinin: number,
    kilip: number,
    heartFailure: boolean,
    stSegmentDeviation: boolean,
    highLevelOfCardiacEnzymes: boolean
) {
    let res: IResult<GraceScaleResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new GraceScaleClient(getAuthClient());
        res.result = await client.calculateGraceScale(
            age,
            heartRate,
            systolicBloodPressure,
            creatinin,
            kilip,
            heartFailure,
            stSegmentDeviation,
            highLevelOfCardiacEnzymes
        );

    } catch (error) {
        res = {
            error: {
                errors: ["Непредвиденная ошибка"],
            },
        };
        return res;
    }

    return res;
}

export async function GetKillip() {
    try {
        let client = new GraceScaleClient(getAuthClient());
        let killip = await client.getKillipDictionary();

        let result: ISelectNameValue[] = [];

        return killip;
    } catch {
    }
}
