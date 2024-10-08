# Instructions
The program should be launched from a command prompt terminal with few argument switches.

Action switches:
<br>``-x`` Extracts text data from a ztr file into a text file
<br>``-c`` Decompressed conversion. this converts the text data from the extracted text file to the ztr format in a decompressed format.
<br>``-c2`` Compressed conversion (slower). this convert the text data from the extracted text file to the ztr format in a compressed format.
<br>``-h`` or ``-?`` Displays the tool's usage instructions.

GameCode switches:
<br>``-ff131`` Use this switch when working with 'FINAL FANATAST XIII' ztr files.
<br>``-ff132`` Use this switch when working with 'FINAL FANATAST XIII-2' ztr files. 
<br>``-ff133`` Use this switch when working with 'LIGHTNING RETURNS FINAL FANATAST XIII' ztr files 

<br>Encoding switches
<br>``-auto`` Automatically determine the encoding to use depending on the ztr/ text filename 
<br>``-ch`` Chinese encoding. use this for chinese language ztr files. ex: txtres_ch.ztr file.
<br>``-kr`` Korean encoding. use this for korean language ztr files. ex: txtres_kr.ztr file.
<br>``-lj`` Latin/ Japanese encoding. use this for english, french, german, italian, japanese and spanish ztr files."

<br>Commandline usage examples:
<br>``ZTRtool.exe -x -ff131 -auto "txtres_us.ztr" ``
<br>``ZTRtool.exe -c -ff131 -auto "txtres_us.txt" ``
<br>``ZTRtool.exe -c2 -ff131 -auto "txtres_us.txt" ``

## Important Notes
- Using notepad++ to view and edit the text is highly recommended. do ensure that you save the file in utf-8 encoding, without BOM or Byte Order Mark.
- Use the appropriate game code and encoding switches when using this tool. this is very important and using a wrong switch can result in incorrect extraction or conversion of the text data.
- Use the ``-lj`` encoding switch when dealing with ZTR files that use latin alphabets and japanese characters.
- The ``-c2`` action switch is recommended only for ZTR files that need to be in a 'compressed' state. for instance the ZTR files packed inside the .bin files that begin with the name `auto_`, located in the folder ``LIGHTNING RETURNS FINAL FANTASY\weiss_data\db\ai\npc\pack``, all require the ZTR files to be in a compressed format.
- The extracted text file would contain special keys along with the text data. a comprehensive list of valid keys can be found in this page linked below:
<br>https://github.com/LR-Research-Team/Datalog/wiki/Encoding-Keys-Info

- Special latin characters like ``À`` would also have to be put inside a `{ }` just like the encoding keys.
- ZTR files that are named ``txtres_ck.ztr`` are all unused by the games and this tool will not extract or convert them properly.
- Make sure not to leave a line empty in between two lines. leaving empty lines in between would cause an exception to be thrown.
- If you are adding new line ids for new lines in the extracted text file, then ensure that the id is added according to the alphabetical order by which the other ids appear in the text file. for instance after the id ``$auto_refa``, if your new id is ``$auto_refab_test`` then this id has to be added right after ``$auto_refa``.
- For developers only. put the `-debug` switch after the ztr filename for dumping raw data of the files during the various extraction/conversion stages.
<br>The following example mentioned below, would launch the tool in a debug state:
<br>``ZTRtool.exe -x -ff131 -auto "txtres_us.ztr" -debug``
