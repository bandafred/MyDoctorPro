import {
    DiaryClient, DiaryGetRecordsResponse
} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";
import {getErrorsFromApiException} from "../../../../apiClient/getErrorsFromApiException";

export async function addRecord(
    systolicBloodPressure: number,
    diastolicBloodPressure: number,
    description: string | null | undefined,
    ambulanceDrugsNumber: number | null | undefined,
    pulse: number,
    glucoseLevel: number | null | undefined,
    date: Date,
    isMorning: boolean) {
    try {
        let client = new DiaryClient(getAuthClient());
        
        await client.addRecord(systolicBloodPressure, diastolicBloodPressure, description, ambulanceDrugsNumber, pulse, glucoseLevel, date, isMorning);

        return undefined;

    } catch (error) {
        return getErrorsFromApiException(error);
    }
}