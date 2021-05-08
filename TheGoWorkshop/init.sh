basepath="/workspace/StudyingBooks/TheGoWorkshop"
chp=`printf "ch%02u" $1`
echo $test
exc=$2
fullpath="${basepath}/${chp}/${exc}"
echo $fullpath
[ ! -d "$fullpath" ] && mkdir -p "$fullpath"
touch "$fullpath/main.go"
cd $fullpath
go mod init example.com/m